# gamedesign_project
 
the game is about shrek travelling to different planets and doing quests

## intro scene
it's the shrek movie intro
The intro can be skipped by pressing the esc or `A` or `x`, it also goes to the menu after it's done playing

## menu
In the menu currently you have the option to start the game exit the game
There is no load save or menu because the game is not there yet.
## ship
the ship scene is the first part of the game, the player can move around and interact with the planet teleporter. 

## planet miter
this is the first planet in the game.
the planet is procedurally generated and has an enemy that can kill you and that you can kill. you can fall off the ground, resulting in death.


## code 
 #### movement

  I check if the axis value is either -1 or 1. This allows for controller support, xbox and playstation.
  I use transform.translate instead of ridgidbody2d because of it's more simple and straightforward to use.  
  ```csharp
        if (Input.GetAxis("Horizontal") > 0)
        {   
            
            m_FacingRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            anim.SetFloat("Speed",Math.Abs(horizontalMove));
  

        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            m_FacingRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            anim.SetFloat("Speed",Math.Abs(horizontalMove));
         
 
        }
 ```        
this is the script that generate the basic world.
it does it via a seed so it generates the same level everytime.
instantiate makes a new copy of a block called grass.
 ```csharp
        void generateChunk()
        {

            Random.InitState(seed);
            distance = height;
            for (int w = 0; w < width; w++)
            {
                int lowernum = distance - 1;
                int heighernum = distance + 2;


                distance = Random.Range(lowernum, heighernum);
                space = Random.Range(1, 8);
                int stonespace = distance - space;


                for (int j = 0; j < stonespace; j++)
                {
                  Instantiate(Stone, new Vector3(w, j), Quaternion.identity);
                }

                for (int j = stonespace; j < distance; j++)
                {
  
                    Instantiate(Dirt, new Vector3(w, j), Quaternion.identity);
                }

                Instantiate(Grass, new Vector3(w, distance), Quaternion.identity);
            }
        }

 ```   

## issues
I wanted to make chunks but as I heard unity is not a good engine for unlimited procedurally generated maps, as it doesn't support threading. 



