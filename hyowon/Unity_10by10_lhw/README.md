
# Unity_10by10

Unity Puzzle Game : TEN by TEN

Drag and make Square to cover Numbers.
When Dragged up and sum of Numbers become " 10 " that Numbers disappear.
time limit is 60s and the removed numbers of Numbers(Bubbles) add to Score.



<img width="600" alt="스크린샷 2021-06-27 오후 6 19 08" src="https://user-images.githubusercontent.com/19869356/123539330-2b71f980-d774-11eb-89ae-c9cb711b7f47.png">

<img width="600" alt="스크린샷 2021-06-27 오후 6 19 39" src="https://user-images.githubusercontent.com/19869356/123539343-3d539c80-d774-11eb-911b-3dc6dec4ad26.png">
<img width="600" alt="스크린샷 2021-06-27 오후 6 21 06" src="https://user-images.githubusercontent.com/19869356/123539393-7d1a8400-d774-11eb-98af-3555599339e4.png">

# In Details

## Board Setting
```C#
.
.
private List<GameObject> Bubbles;
.
.
void SettingBoard(){
  for (float i = 4; i > -4; i -= 0.8f)
      {
        for (float j = -7; j < 8; j += 0.8f)
        {
          GameObject bubble = (GameObject)Instantiate(NumPrefab[Random.Range(0, 9)],
          new Vector2(j, i),
          Quaternion.identity);
          Bubbles.Add(bubble);
        }
      }
}
```
* Make a Bubble(Number-Block) from prefab resources **randomly** and add to List to supervise them
* Each Bubbles' size are same to *Unit size 4*. So I made a virtual grid position and arrange them to each position
* Tought that float *0.8* can be replaced with **size of Prefab**

## Mouse Dragging Effect
```C#
.
.
private RectTransform SelectField;
.
.
void MouseDrag(Vector2 curMousePos)
  {
    SelectField.gameObject.SetActive(true);
    float width = curMousePos.x - MouseInit.x;
    float height = curMousePos.y - MouseInit.y;

    SelectField.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
    SelectField.anchoredPosition = MouseInit + new Vector2(width / 2, height / 2);
  }
```
* Make a Canvs-Image, resizing and repositioning at first mouse click and after mouse movement.
* Position a Image at **Left-Bottom** pivot and calculate its width, height, center pivot position in Update func

## Caculate Bubbles
```C#
private void SelectBubbles(Vector2 curMousePos)
  {
    Vector2 max, min;
    Color32 preColor = new Color32(243, 125, 125, 255);
    Color32 postColor = new Color32(96, 149, 245, 255);
    foreach (GameObject el in Bubbles)
    {
      Vector2 pos = el.transform.position;
      if (startSelectPos.x > curMousePos.x)
      {
        max.x = startSelectPos.x;
        min.x = curMousePos.x;
      }
      else
      {
        max.x = curMousePos.x;
        min.x = startSelectPos.x;
      }
      if (startSelectPos.y > curMousePos.y)
      {
        max.y = startSelectPos.y;
        min.y = curMousePos.y;
      }
      else
      {
        max.y = curMousePos.y;
        min.y = startSelectPos.y;
      }

      if (pos.x >= min.x && pos.x <= max.x
      && pos.y >= min.y && pos.y <= max.y)
      {
        el.transform.localScale = Vector3.Lerp(el.transform.localScale, new Vector3(5.5f, 5.5f, 0), Time.deltaTime * 10);
        el.transform.GetChild(0).GetComponent<SpriteRenderer>().color = postColor;

        if (!CheckDict.ContainsKey(el))
        {
          CheckDict.Add(el, int.Parse(el.name.Split('_')[1].Split('(')[0]));
        }
      }
      else
      {
        el.transform.localScale = Vector3.Lerp(el.transform.localScale, new Vector3(5, 5, 0), Time.deltaTime * 10);
        el.transform.GetChild(0).GetComponent<SpriteRenderer>().color = preColor;
      }
    }
  }
```
### Bubble Select Judgement
Bubble selection judgement needed 4-way calculation : Mouse Click from **LEFT-TOP, LEFT-BOTTOM, RIGHT-TOP, RIGHT-BOTTOM**
So I made 4 conditional statement for calculate them.
* if Bubbles are in that selection box, it change its color in Lerp and Add to **CheckDict** Dictionary.
* **CheckDict** Dictionary used for *Is Bubble's sum 10 or not*
* **DUPLICATE CHECK** : used *Dictionary<GameObject, int> CheckDict*. GameObject has its soley own name so I use it for KEY and Value as that Object's number.
So it can prevent Duplicated selection issues. 

### Sum of Bubbles Calculate
```C#
.
.
void Update(){
...
...
  if (Input.GetMouseButtonUp(0))
  {
    SelectField.gameObject.SetActive(false);
    UndoBubbles();


    foreach (KeyValuePair<GameObject, int> el in CheckDict)
    {
      sum += CheckDict[el.Key];
    }
    Debug.Log(sum);
    if (sum == GoalNum)
    {
      foreach (KeyValuePair<GameObject, int> el in CheckDict)
      {
        Destroy(el.Key);
        Bubbles.Remove(el.Key);
      }
      score += CheckDict.Count;
      ScoreTMPro.text = score.ToString();
    }
    sum = 0;
  }
.
.
```
* Calcualte only when after MouseButton Up
* looping **Checkdict** elememt for its sum and if sum is 10, Destroy Objects and remove them in **Bubble-List**
