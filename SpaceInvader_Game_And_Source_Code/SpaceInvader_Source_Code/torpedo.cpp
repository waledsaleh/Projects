
#include "torpedo.h"

//=============================================================================
// default constructor
//=============================================================================
Torpedo::Torpedo() : Entity()
{
    active = false;                                 // torpedo starts inactive
    spriteData.width        = torpedoNS::WIDTH;     // size of 1 image
    spriteData.height       = torpedoNS::HEIGHT;
    spriteData.rect.bottom  = torpedoNS::HEIGHT;    // rectangle to select parts of an image
    spriteData.rect.right   = torpedoNS::WIDTH;
    cols            = torpedoNS::TEXTURE_COLS;
    frameDelay       = torpedoNS::ANIMATION_DELAY;
    startFrame      = torpedoNS::START_FRAME;       // first frame of ship animation
    endFrame        = torpedoNS::END_FRAME;         // last frame of ship animation
    currentFrame    = startFrame;
    radius          = torpedoNS::COLLISION_RADIUS;  // for circular collision
    visible         = false;
    fireTimer       = 0.0f;
    mass = torpedoNS::MASS;
    collisionType = entityNS::CIRCLE;
}

//=============================================================================
// update
// typically called once per frame
// frameTime is used to regulate the speed of movement and animation
//=============================================================================
void Torpedo::update(float frameTime)
{
    fireTimer -= frameTime;                     // time remaining until fire enabled

    if (visible == false)
        return;

    if(fireTimer < 0)                           // if ready to fire
    {
        visible = false;                        // old torpedo off
        active = false;
    }

    Image::update(frameTime);

    spriteData.x += frameTime * velocity.x;     // move along X 
    spriteData.y += frameTime * velocity.y;     // move along Y

    // Wrap around screen edge
    if (spriteData.x > GAME_WIDTH)              // if off right screen edge
        spriteData.x = -torpedoNS::WIDTH;       // position off left screen edge
    else if (spriteData.x < -torpedoNS::WIDTH)  // else if off left screen edge
        spriteData.x = GAME_WIDTH;              // position off right screen edge
    if (spriteData.y > GAME_HEIGHT)             // if off bottom screen edge
        spriteData.y = -torpedoNS::HEIGHT;      // position off top screen edge
    else if (spriteData.y < -torpedoNS::HEIGHT) // else if off top screen edge
        spriteData.y = GAME_HEIGHT;             // position off bottom screen edge
}

//=============================================================================
// fire
// Fires a torpedo from ship
//=============================================================================
void Torpedo::fire(Entity *ship)
{
    if(fireTimer <= 0.0f)                       // if ready to fire
    {
        velocity.x = (float)cos(ship->getRadians()) * torpedoNS::SPEED;
        velocity.y = (float)sin(ship->getRadians()) * torpedoNS::SPEED;
        spriteData.x = ship->getCenterX() - spriteData.width/2;
        spriteData.y = ship->getCenterY() - spriteData.height/2;
        visible = true;                         // make torpedo visible
        active = true;                          // enable collisions
        fireTimer = torpedoNS::FIRE_DELAY;      // delay firing
        audio->playCue(TORPEDO_FIRE);
    }
}

