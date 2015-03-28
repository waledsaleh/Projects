

#ifndef _SHIP_H                 // Prevent multiple definitions if this 
#define _SHIP_H                 // file is included in more than one place
#define WIN32_LEAN_AND_MEAN

#include "entity.h"
#include "constants.h"

namespace shipNS
{
    const int   WIDTH = 32;                 // image width (each frame)
    const int   HEIGHT = 32;                // image height
    const int   X = GAME_WIDTH/2 - WIDTH/2; // location on screen
    const int   Y = GAME_HEIGHT/6 - HEIGHT;
    const float ROTATION_RATE = (float)PI; // radians per second
    const float SPEED = 120,speed=100,AI_SPEED=20;                // 100 pixels per second
    const float MASS = 300.0f;              // mass
    enum DIRECTION {NONE, LEFT, RIGHT};     // rotation direction
    const int   TEXTURE_COLS = 8;           // texture has 8 columns
    const int   SHIP1_START_FRAME = 0;      // ship1 starts at frame 0
    const int   SHIP1_END_FRAME = 7;        // ship1 animation frames 0,1,2,3


    const int   SHIP2_START_FRAME = 8;      // ship2 starts at frame 8
    const int   SHIP2_END_FRAME = 11;       // ship2 animation frames 8,9,10,11
    const float SHIP_ANIMATION_DELAY = 0.2f;    // time between frames


    const int   EXPLOSION_START_FRAME = 32; // explosion start frame
    const int   EXPLOSION_END_FRAME = 39;   // explosion end frame
    const float EXPLOSION_ANIMATION_DELAY = 0.1f;   // time between frames


    const int   ENGINE_START_FRAME = 16;    // engine start frame
    const int   ENGINE_END_FRAME = 19;      // engine end frame
    const float ENGINE_ANIMATION_DELAY = 0.1f;  // time between frames
    const int   SHIELD_START_FRAME = 24;    // shield start frame
    const int   SHIELD_END_FRAME = 27;      // shield end frame
    const float SHIELD_ANIMATION_DELAY = 0.1f; // time between frames
    const float TORPEDO_DAMAGE = 100;        // amount of damage caused by torpedo
    const float SHIP_DAMAGE = 10;           // damage caused by collision with another ship
}

// inherits from Entity class
class Ship : public Entity
{
private:
    float   oldX, oldY, oldAngle;
    float   rotation;               // current rotation rate (radians/second)
    shipNS::DIRECTION direction;    // direction of rotation
    float   explosionTimer;
    bool    explosionOn;
    bool    engineOn;               // true to move ship forward
    bool    shieldOn;
    Image   engine;
    Image   shield;
    Image   explosion;
	TextureManager gameTextures;

public:
    // constructor
    Ship();

    // inherited member functions
    virtual void draw();
    virtual bool initialize(Game *gamePtr, int width, int height, int ncols,
                            TextureManager *textureM);

    // update ship position and angle
    void update(float frameTime);

    // damage ship with WEAPON
    void damage(WEAPON);

    // new member functions
    
    // move ship out of collision
    void toOldPosition()            
    {
        spriteData.x = oldX; 
        spriteData.y = oldY, 
        spriteData.angle = oldAngle;
        rotation = 0.0f;
    }

    // Returns rotation
    float getRotation() {return rotation;}

    // Returns engineOn condition
    bool getEngineOn()  {return engineOn;}

    // Returns shieldOn condition
    bool getShieldOn()  {return shieldOn;}

    // Sets engine on
    void setEngineOn(bool eng)  {engineOn = eng;}

    // Set shield on
    void setShieldOn(bool sh)   {shieldOn = sh;}

    // Sets Mass
    void setMass(float m)       {mass = m;}

    // Set rotation rate
    void setRotation(float r)   {rotation = r;}

    // direction of rotation force
    void rotate(shipNS::DIRECTION dir) {direction = dir;}

    // ship explodes
    void explode();

    // ship is repaired
    void repair();
};
#endif

