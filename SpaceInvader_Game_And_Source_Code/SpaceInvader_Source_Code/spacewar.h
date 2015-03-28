

#ifndef _SPACEWAR_H             // Prevent multiple definitions if this 
#define _SPACEWAR_H             // file is included in more than one place
#define WIN32_LEAN_AND_MEAN

#include <string>
#include "game.h"
#include "textureManager.h"
#include "image.h"
#include "dashboard.h"
#include "planet.h"
#include "ship.h"
#include "torpedo.h"

namespace spacewarNS
{
    const char FONT[] = "Arial Bold";  // font
    const int FONT_BIG_SIZE = 220;     // font height
    const int FONT_SCORE_SIZE = 48;
    const COLOR_ARGB FONT_COLOR = graphicsNS::YELLOW;
    const COLOR_ARGB SHIP1_COLOR = graphicsNS::BLUE;
    const COLOR_ARGB SCORE_COLOR = graphicsNS::YELLOW;
    const int SCORE_Y = 10;
    const int SCORE1_X = 30;
    const int SCORE2_X = GAME_WIDTH-80;
    const int HEALTHBAR_Y = 10;
    const int SHIP1_HEALTHBAR_X = 10;
    const int SHIP2_HEALTHBAR_X = GAME_WIDTH-100;
    const int COUNT_DOWN_X = GAME_WIDTH/2 - FONT_BIG_SIZE/4;
    const int COUNT_DOWN_Y = GAME_HEIGHT/2 - FONT_BIG_SIZE/2;
    const int COUNT_DOWN = 3;           // count down from 5
	const int COUNT2_DOWN = 8;
	const int COUNT3_DOWN = 6;
    const int BUF_SIZE = 15;
    const int ROUND_TIME = 5;           // time until new round starts
}

//=============================================================================
// This class is the core of the game
//=============================================================================
class Spacewar : public Game
{
private:
    // game items
    TextureManager menuTexture, nebulaTexture, ship1_texture,torpedo_texture,invad_text,gameTextures,gameOver,Victory_Text;   // textures
    Ship    ship1,AI;       // spaceships
	Ship invad[5][5];
	double count ,posy,posx;
	int gameover;
    Torpedo torpedo1; // torpedoes
    Planet  planet;             // the planet
    Image   nebula,game;             // backdrop image
    Image   menu,exp,game_over,AI_Image,Victory;               // menu image
    Bar     healthBar;          // health bar for ships
    TextDX  fontBig;            // DirectX font for game banners
    TextDX  fontScore;
    bool    menuOn;
    bool    countDownOn,count2down;        // true when count down is displayed
    float   countDownTimer,count2,count3;
    char buffer[spacewarNS::BUF_SIZE];
    bool    ship1Scored, ship2Scored;   // true if ship scored during round
    bool    roundOver;          // true when round is over
    float   roundTimer;         // time until new round starts
    int     ship1Score, ship2Score; // scores
    bool    musicOff;           // true to turn music off
	bool first,sec;
	bool attack;
	int move;
	int speed;
	bool restart;
	bool start;
	bool show;
	bool s1,s2;
	int pos;

public:
    // Constructor
    Spacewar();
    // Destructor
    virtual ~Spacewar();
    // Initialize the game
    void initialize(HWND hwnd);
    void update();      // must override pure virtual from Game
    void ai();          // "
    void collisions();  // "
    void render();      // "
    void consoleCommand(); // process console command
    void roundStart();  // start a new round of play
    void releaseAll();
    void resetAll();
};

#endif
