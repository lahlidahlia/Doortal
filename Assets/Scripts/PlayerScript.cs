using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public LayerMask lightLayerMask;
    Vector2 playerPos;
    public float speed; //How fast the player moves
    public GameObject Door;
    public GameObject Wall;

    enum Direction{W, E, N, S}; 
    private Direction direction; //direction that the player is facing

    public int rayCastAmnt; //Amount of rays being cast to check for visibility

    public float shadowLength;
    public float shadowOffset;
    public float visionRange;

    public Color defaultColor1;
    public Color defaultColor2;
    private SpriteRenderer spriteRenderer;

    public Color playerRed;
    public Color playerBlue;
    public Color playerGreen;
    public Color playerMagenta;
    public Color playerCyan;
    public Color playerYellow;
    public Color playerWhite;

    private Color currentColor;
    public float colorTransSpeed;

    public ParticleSystem part_ColorPlate;


    public static bool isInWall;
	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Global.PlayerColor1 = defaultColor1;
        Global.PlayerColor2 = defaultColor2;
	}

    


    void Update() {
        //Selecting color slots to determine which color will be swap out when player changes color.
        if ((Input.GetButtonDown("ColorToggle") && Global.colorSelected == false) || Global.PlayerColor1 == Color.white)
        {
            Global.colorSelected = true;
        }
        else if (((Input.GetButtonDown("ColorToggle") && Global.colorSelected == true) || Global.PlayerColor2 == Color.white) && Application.loadedLevel != 4) //If the player has white in his inventory, automatically select it, to avoid having white in the inventory. Doesn't allow player to switch color during level 1
        {
            Global.colorSelected = false;
        }
        //Debug.Log(Global.colorSelected);


        //Determining player combined color
        if (Global.PlayerColor2 != Color.white){
            //Debug.Log("PlayerColor1 = " + Global.PlayerColor1.ToString());
            //Debug.Log("PlayerColor2 = " + Global.PlayerColor2.ToString());
            
            //Figure out the combined color when there is two different colors in the inventory
            if ((Global.PlayerColor1 == Color.red && Global.PlayerColor2 == Color.green) ||
                (Global.PlayerColor1 == Color.green && Global.PlayerColor2 == Color.red)){ //Red + green = yellow
                Global.PlayerColorCombined = new Color(1,1,0,1);
            }
            else if ((Global.PlayerColor1 == Color.red && Global.PlayerColor2 == Color.blue) ||
                (Global.PlayerColor1 == Color.blue && Global.PlayerColor2 == Color.red)){ //Red + blue = magenta
                Global.PlayerColorCombined = Color.magenta;
            }
            else if ((Global.PlayerColor1 == Color.green && Global.PlayerColor2 == Color.blue) ||
                (Global.PlayerColor1 == Color.blue && Global.PlayerColor2 == Color.green)){ //green + blue = cyan
                Global.PlayerColorCombined = Color.cyan;
            }
            else if ((Global.PlayerColor1 == Color.magenta && Global.PlayerColor2 == new Color(1,1,0)) ||
                (Global.PlayerColor1 == new Color(1,1,0) && Global.PlayerColor2 == Color.magenta)){ //magenta + yellow = red
                Global.PlayerColorCombined = Color.red;
            }
            else if ((Global.PlayerColor1 == Color.cyan && Global.PlayerColor2 == new Color(1,1,0)) ||
                (Global.PlayerColor1 == new Color(1,1,0) && Global.PlayerColor2 == Color.cyan)){ //cyan + yellow = green
                Global.PlayerColorCombined = Color.green;
            }
            else if ((Global.PlayerColor1 == Color.cyan && Global.PlayerColor2 == Color.magenta) ||
                (Global.PlayerColor1 == Color.magenta && Global.PlayerColor2 == Color.cyan)){ //cyan + magenta = blue
                Global.PlayerColorCombined = Color.blue;
            }
            else{ //If colors are on opposite end of the spectrum
                Global.PlayerColorCombined = Color.black;
                
            }
            //Combining the color into one slot
            if (Input.GetButtonDown("CombineColor"))
            {
                Global.PlayerColor1 = Global.PlayerColorCombined;
                Global.PlayerColor2 = Color.white;
            }
        }
        else {//If one color is white or both color is the same
            Global.PlayerColorCombined = Global.PlayerColor1;
            Debug.Log(Global.PlayerColorCombined);
        }
        Global.PlayerColorCombined.a = 1;
        //Debug.Log(Global.PlayerColorCombined.ToString());
        //Setting the player's color based on combined color
        //if (Global.PlayerColorCombined == Color.white) {
        //    currentColor = playerWhite;
        //}
        //if (Global.PlayerColorCombined == Color.blue)
        //{
        //    currentColor = playerBlue;
        //}
        //if (Global.PlayerColorCombined == Color.red)
        //{
        //    currentColor = playerRed;
        //}
        //if (Global.PlayerColorCombined == Color.green)
        //{
        //    currentColor = playerGreen;
        //}
        //if (Global.PlayerColorCombined == Color.magenta)
        //{
        //    currentColor = playerMagenta;
        //}
        //if (Global.PlayerColorCombined == Color.cyan)
        //{
        //    currentColor = playerCyan;
        //}
        //if (Global.PlayerColorCombined == new Color(1, 1, 0, 1)) //Because Color.yellow is (1, 0.92, 0.016, 1) but we want to check for pure yellow
        //{
        //    currentColor = playerYellow;
        //}
        currentColor = Global.PlayerColorCombined;
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, currentColor, colorTransSpeed * Time.deltaTime);

        //Casting rays and creating dynamic shadows
        playerPos = new Vector2(transform.position.x, transform.position.y); //Changing player position into a vector2 instead of v3
        Vector2 prevPoint1 = new Vector2(-9999, -9999); //Previous points are used to keep track of previous ray hits in order to draw quads
        Vector2 prevPoint2 = new Vector2(-9999, -9999); //Initialized as -9999 because you can't initialize it as null
        Vector2 startPoint1 = new Vector2(-9999, -9999); //The first ray hit position. Used to connect the last ray hit and the first ray hit together
        Vector2 startPoint2 = new Vector2(-9999, -9999);
        for (int i = 0; i < rayCastAmnt; i++) //Iterate through all the rays
        {
            float angle = (float)i / (float)rayCastAmnt * 360; //Figure out what angle the ray is in degree.
            float cos = Mathf.Cos(angle * Mathf.Deg2Rad); //Figure out the cosine of the angle.  Also turn the angle into radians because mathf.sin/cos only take radians
            float sin = Mathf.Sin(angle * Mathf.Deg2Rad); //Figure out the sine of the angle.
            Vector2 direction = new Vector2(cos, sin); //Figure out the direction of the raycast (in vector form, e.g. 30deg would be (cos(30),sin(30))).
            RaycastHit2D rayhit = Physics2D.Raycast(transform.position, direction, visionRange, lightLayerMask); //Cast the ray and store the hit info
            Vector2 hitPoint;
            if (rayhit.transform == null){ //check if the ray hits nothing
                hitPoint = new Vector2(cos * visionRange, sin * visionRange) + playerPos;
            }
            else { //If the ray hits something
                hitPoint = rayhit.point;
            }
            
            //Renderer ren = obj.transform.GetComponent<Renderer>();
            //ren.enabled = true;
            Vector2 curPoint1 = hitPoint + new Vector2(cos * shadowOffset, sin * shadowOffset); //Ray hit point + shadow offset
            Vector2 curPoint2 = hitPoint + new Vector2(cos * shadowLength, sin * shadowLength); //Ray hit point + shadow length

            if (prevPoint1 == new Vector2(-9999, -9999) && prevPoint2 == new Vector2(-9999, -9999)) { //If "uninitialized"
                prevPoint1 = curPoint1;
                prevPoint2 = curPoint2;
                startPoint1 = curPoint1; //Set first ray hit point, so we can connect the first and last together later
                startPoint2 = curPoint2;
                continue;
            }

            //Draw the shadows
            DrawScript.drawList.Add(prevPoint1);
            DrawScript.drawList.Add(curPoint1);
            DrawScript.drawList.Add(curPoint2);
            DrawScript.drawList.Add(prevPoint2);

            prevPoint1 = curPoint1;
            prevPoint2 = curPoint2;

            if (i == rayCastAmnt - 1) { //If the last ray is casted, draw a shadow connecting the first and last shadow together
                DrawScript.drawList.Add(startPoint1);
                DrawScript.drawList.Add(curPoint1);
                DrawScript.drawList.Add(curPoint2);
                DrawScript.drawList.Add(startPoint2);
            }

        }


    }
	



	// Update is called once every 0.2 seconds (not every frame)
	void FixedUpdate () {

        //Get keyboard input for the movement and calculate the player's velocity
        float horMove = Input.GetAxisRaw("Horizontal") * speed; 
        float verMove = Input.GetAxisRaw("Vertical") * speed;
        rigidbody2D.velocity = new Vector2(horMove, verMove); //Set the velocity

        //Determine facing direction
        if (horMove > 0) { 
            direction = Direction.E;
        }
        if (horMove < 0) {
            direction = Direction.W;
        }
        if (verMove > 0) { 
            direction = Direction.N;
        }
        if (verMove < 0) {
            direction = Direction.S;
        }

        if (Input.GetButtonDown("PlaceDoor")) {
            placeDoor(direction);
        }
	}





    void placeDoor(Direction dir) { //Place a door at the player's position if there he is on a wall
        GameObject existingDoor = GameObject.FindWithTag("Door");
        if (existingDoor != null)
        {
            DoorScript dscr = existingDoor.GetComponent<DoorScript>();
            //Check if the player is nearby
            Collider2D[] objs = Physics2D.OverlapCircleAll(existingDoor.transform.position, 0.1f); //Get obj nearby the door
            foreach (Collider2D o in objs) {
                //Debug.Log(o.transform);
                if (o.tag == "Player") { //If player is standing on the door
                    return;              //Exit
                }
            }


            //Destroy existing the door and replace it with a wall
            GameObject w = Instantiate(Wall, existingDoor.transform.position, Quaternion.identity) as GameObject;
            WallColorScript wscr = w.GetComponent<WallColorScript>();
            wscr.color = dscr.color;
            Destroy(existingDoor);
            

        }

        //Determine the door's relative position to the player based on input direction
        //int relX = 0;
        //int relY = 0;        
        //if (dir == Direction.W) {
        //    relX = -1;
        //}
        //if (dir == Direction.E)
        //{
        //    relX = 1;
        //}
        //if (dir == Direction.N)
        //{
        //    relY = 1;
        //}
        //if (dir == Direction.S)
        //{
        //    relY = -1;
        //}

        //Calculating door's position
        //Vector3 tDoorPos = transform.position + new Vector3(relX, relY, 0); //Temporary variable used to calculate door's position without rounding
        Vector3 tDoorPos = transform.position; //Temporary variable used to calculate door's position without rounding
        Vector3 doorPos = new Vector3(Mathf.Round(tDoorPos.x), Mathf.Round(tDoorPos.y), 0); //Final door position

        //Checks if the door position is applicable (I.e. must overlap a wall)
        Collider2D[] walls = Physics2D.OverlapCircleAll(transform.position, 1f); //Get all the walls around player
        bool canCreateDoor = false;
        foreach(Collider2D w in walls){ //Checks all wall in a small area around the player
            if (w.tag != "Player" && w.tag != "SteelWall"){ //Make sure to exclude the player and steel wall in the checks (If trying to create door on steel wall, it would skip it)
                //Debug.Log(doorPos.ToString() + " : " + w.transform.position.ToString());
                if (w.transform.position == doorPos){
                    WallColorScript wscr = w.GetComponent<WallColorScript>();
                    if (wscr.color == Global.PlayerColor1 || wscr.color == Global.PlayerColor2 || wscr.color == Global.PlayerColorCombined)
                    {
                        canCreateDoor = true; //If the door overlaps a wall
                        //Debug.Log(canCreateDoor);
                        break;
                    }
                }
            }
        }
        if (canCreateDoor == false) {
            Debug.Log(canCreateDoor);
            return;
        }

        //Instantiate the door with position based on input direction
        

        //Get the wall that the door collided with's info and delete it
        Collider2D[] tWalls = Physics2D.OverlapCircleAll(new Vector2(doorPos.x, doorPos.y), 0.1f);
        //Debug.Log(wall);
        WallColorScript wallScript;
        foreach(Collider2D wall in tWalls){
            if (wall.tag == "Wall")
            {
                wallScript = wall.GetComponent<WallColorScript>();
                GameObject door = Instantiate(Door, doorPos, Quaternion.identity) as GameObject; //Create the door with position rounded down
                DoorScript scr = door.GetComponent<DoorScript>();
                //scr.color = new Color(Global.PlayerColorCombined.r, Global.PlayerColorCombined.g, Global.PlayerColorCombined.b);
                scr.color = wallScript.color;
                Destroy(wall.gameObject);
                break;
            }
        }
    }

    //void OnTriggerEnter2D(Collider2D other) {
    //    if (other.tag == "Wall" && !isInWall) {
    //        SoundScript.Sound.MakePasswallSound();
    //        isInWall = true;
    //    }
        //if (other.tag == "ColorPlate") {
        //    Debug.Log("COLOR CHANGE!");
        //    ColorPlateScript scr = other.GetComponent<ColorPlateScript>();
        //    if (Global.PlayerColor1 != scr.color && Global.PlayerColor2 != scr.color && Global.PlayerColorCombined != scr.color){
                
        //        ParticleSystem part = Instantiate(part_ColorPlate, transform.position, Quaternion.identity) as ParticleSystem;
        //        part.startColor = scr.color;
        //    }
        //}
    //}

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Wall" && !isInWall) {
            isInWall = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        bool isOutOfWall = true; //If the player is completely out of the wall (i.e. Not touching any other walls)
        Collider2D[] tWalls = Physics2D.OverlapCircleAll(transform.position, 0.4f);
        //Debug.Log(tWalls);
        foreach (Collider2D wall in tWalls) {
            if (wall.tag == "Wall") { //To omit anything not walls
                isOutOfWall = false; 
                break;
            }
        }
        if (other.tag == "Wall" && isOutOfWall) {
            isInWall = false;
            //Debug.Log("Is out of wall now!");   
        }
    }
}
