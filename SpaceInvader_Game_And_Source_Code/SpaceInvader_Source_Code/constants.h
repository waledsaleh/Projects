

#ifndef _CONSTANTS_H            // Prevent multiple definitions if this 
#define _CONSTANTS_H            // file is included in more than one place
#define WIN32_LEAN_AND_MEAN

#include <windows.h>

//=============================================================================
//                  Constants
//=============================================================================

// window
const char CLASS_NAME[] = "Spacewar";
const char GAME_TITLE[] = "Spacewar";
const bool FULLSCREEN = false;              // windowed or fullscreen
const UINT GAME_WIDTH =  680;               // width of game in pixels
const UINT GAME_HEIGHT = 480;               // height of game in pixels
 
// game
const bool VSYNC = true;                    // true locks display to vertical sync rate
const float FRAME_RATE = 240.0f;            // the target frame rate (frames/sec), ignored if VSYNC is true
const float MIN_FRAME_RATE = 10.0f;             // the minimum frame rate
const float MIN_FRAME_TIME = 1.0f/FRAME_RATE;   // minimum desired time for 1 frame
const float MAX_FRAME_TIME = 1.0f/MIN_FRAME_RATE; // maximum time used in calculations
const float FULL_HEALTH = 100;
const double PI = 3.14159265;

// graphic images
const char NEBULA_IMAGE[] =   "pictures\\mainbackground.png";     // photo source NASA/courtesy of nasaimages.org 
const char SHIP_IMAGE[] = "pictures\\shipanimation.png";

const char MENU_IMAGE[] =     "pictures\\menu.png";      // menu texture

// audio files required by audio.cpp
// WAVE_BANK must be location of .xwb file.
const char WAVE_BANK[]  = "audio\\Win\\waveBank.xwb";
// SOUND_BANK must be location of .xsb file.
const char SOUND_BANK[] = "audio\\Win\\soundBank.xsb";
// XGS_FILE must be location of .xgs file.
const char XGS_FILE[]   = "audio\\Win\\SpaceWar.xgs";


// audio cues
const char CHEER[]          = "cheer";
const char COLLIDE[]        = "collide";
const char EXPLODE[]        = "explode";
const char ENGINE1[]        = "engine1";
const char ENGINE2[]        = "engine2";
const char TORPEDO_CRASH[]  = "torpedoCrash";
const char TORPEDO_FIRE[]   = "torpedoFire";
const char TORPEDO_HIT[]    = "torpedoHit";


const char ACTION_THEME[]   = "actionTheme";
const char GAME_PLAY[]    = "gameMusic";
const char MENU_MUSIC[]    = "audio\\menuMusic.wav";


// key mappings
// In this game simple constants are used for key mappings. If variables were used
// it would be possible to save and restore key mappings from a data file.
const UCHAR CONSOLE_KEY  = '`';         // ` key
const UCHAR ESC_KEY      = VK_ESCAPE;   // escape key
const UCHAR ALT_KEY      = VK_MENU;     // Alt key
const UCHAR ENTER_KEY    = VK_RETURN;   // Enter key
const UCHAR SHIP1_LEFT_KEY    = 'A';
const UCHAR SHIP1_RIGHT_KEY   = 'D';
const UCHAR SHIP1_FORWARD_KEY = 'W';
const UCHAR SHIP1_FIRE_KEY    = 'S';
const UCHAR SHIP2_LEFT_KEY    = VK_LEFT; // left arrow
const UCHAR SHIP2_RIGHT_KEY   = VK_RIGHT; // right arrow
const UCHAR SHIP2_FORWARD_KEY = VK_UP;   // up arrow
const UCHAR SHIP2_FIRE_KEY    = VK_DOWN; // down arrow

// weapon types
enum WEAPON {TORPEDO, SHIP, PLANET};

//=============================================================================
// Function templates for safely dealing with pointer referenced items.
// The functions defined by these templates may be called using a normal
// function call syntax. The compiler will create a function that replaces T
// with the type of the calling parameter.
//=============================================================================
// Safely release pointer referenced item
template <typename T>
inline void safeRelease(T& ptr)
{
    if (ptr)
    { 
        ptr->Release(); 
        ptr = NULL;
    }
}
#define SAFE_RELEASE safeRelease            // for backward compatiblility

// Safely delete pointer referenced item
template <typename T>
inline void safeDelete(T& ptr)
{
    if (ptr)
    { 
        delete ptr; 
        ptr = NULL;
    }
}
#define SAFE_DELETE safeDelete              // for backward compatiblility

// Safely delete pointer referenced array
template <typename T>
inline void safeDeleteArray(T& ptr)
{
    if (ptr)
    { 
        delete[] ptr; 
        ptr = NULL;
    }
}
#define SAFE_DELETE_ARRAY safeDeleteArray   // for backward compatiblility

// Safely call onLostDevice
template <typename T>
inline void safeOnLostDevice(T& ptr)
{
    if (ptr)
        ptr->onLostDevice(); 
}
#define SAFE_ON_LOST_DEVICE safeOnLostDevice    // for backward compatiblility

// Safely call onResetDevice
template <typename T>
inline void safeOnResetDevice(T& ptr)
{
    if (ptr)
        ptr->onResetDevice(); 
}
#define SAFE_ON_RESET_DEVICE safeOnResetDevice  // for backward compatiblility

#endif
