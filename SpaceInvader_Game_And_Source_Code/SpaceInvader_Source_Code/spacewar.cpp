

#include "spaceWar.h"


//=============================================================================
// Constructor
//=============================================================================
Spacewar::Spacewar()
{
	double rotate =90.0;
	menuOn = true;
	countDownOn = false;
	roundOver = false;
	ship1Score = 0;
	ship2Score = 0;
	ship1Scored = false;
	ship2Scored = false;
	initialized = false;
	musicOff = false;
	first=false;
	sec =false;
	gameover=0;
	move =0;
	speed = 35;
	restart=false;
	start = false;
}

//=============================================================================
// Destructor
//=============================================================================
Spacewar::~Spacewar()
{
	releaseAll();           // call onLostDevice() for every graphics item
}

//=============================================================================
// Initializes the game
// Throws GameError on error
//=============================================================================
void Spacewar::initialize(HWND hwnd)
{
	Game::initialize(hwnd); // throws GameError
	count=0 ;
	posy=90;
	posx=200;
	// initialize DirectX fonts
	fontBig.initialize(graphics, spacewarNS::FONT_BIG_SIZE, false, false, spacewarNS::FONT);
	fontBig.setFontColor(spacewarNS::FONT_COLOR);
	fontScore.initialize(graphics, spacewarNS::FONT_SCORE_SIZE, false, false, spacewarNS::FONT);

	if (!gameTextures.initialize(graphics,"pictures\\textures.png"))
		throw(GameError(gameErrorNS::FATAL_ERROR, "Error initializing game textures"));
	

	if (!AI.initialize(this,shipNS::WIDTH,shipNS::HEIGHT,8,&gameTextures))
		throw(GameError(gameErrorNS::FATAL_ERROR, "Error initializing game textures"));

	AI.setFrames(shipNS::SHIP2_START_FRAME, shipNS::SHIP2_END_FRAME);
	AI.setCurrentFrame(shipNS::SHIP2_START_FRAME);
	AI.setColorFilter(SETCOLOR_ARGB(255,230,230,255));   // light blue, used for shield and torpedo
	AI.setDegrees(180.0f);
	AI.setMass(shipNS::MASS);
	AI.setY(0);


	/*  menu texture*/
	if (!menuTexture.initialize(graphics,MENU_IMAGE))
		throw(GameError(gameErrorNS::FATAL_ERROR, "Error initializing menu texture"));

	// nebula texture
	if (!nebulaTexture.initialize(graphics,NEBULA_IMAGE))
		throw(GameError(gameErrorNS::FATAL_ERROR, "Error initializing nebula texture"));

	if (!gameOver.initialize(graphics,"pictures\\endMenu.png"))
		throw(GameError(gameErrorNS::FATAL_ERROR, "Error initializing nebula texture"));

	if (!game.initialize(graphics,GAME_WIDTH,GAME_HEIGHT,0,&gameOver))
		throw(GameError(gameErrorNS::FATAL_ERROR, "Error initializing nebula texture"));

	
	if (!Victory_Text.initialize(graphics,"pictures\\victory.jpg"))
		throw(GameError(gameErrorNS::FATAL_ERROR, "Error initializing game textures"));
	if (!Victory.initialize(graphics,GAME_WIDTH,GAME_HEIGHT,0,&Victory_Text))
		throw(GameError(gameErrorNS::FATAL_ERROR, "Error initializing game textures"));



	for(int i = 0 ; i<5;++i)
	{
		for(int j = 0 ; j <5;++j)
		{
			if (!invad[i][j].initialize(this,shipNS::WIDTH,shipNS::HEIGHT,8,&gameTextures))
				throw(GameError(gameErrorNS::FATAL_ERROR, "Error initializing nebula texture"));

			invad[i][j].setFrames(shipNS::SHIP1_START_FRAME,3);
			invad[i][j].setCurrentFrame(shipNS::SHIP1_START_FRAME);
			invad[i][j].setColorFilter(SETCOLOR_ARGB(255,230,230,255));   // light blue, used for shield and torpedo
			invad[i][j].setMass(shipNS::MASS);
			invad[i][j].setDegrees(90.0f);

			invad[i][j].setX(posx+count - shipNS::WIDTH);

			invad[i][j].setY(posy - shipNS::HEIGHT);
			count +=70;

		}
		posy +=40;
		count =0;

	}


	// main game textures
	if (!ship1_texture.initialize(graphics,SHIP_IMAGE))
		throw(GameError(gameErrorNS::FATAL_ERROR, "Error initializing Ship texture"));

	// menu image
	if (!menu.initialize(graphics,0,0,0,&menuTexture))
		throw(GameError(gameErrorNS::FATAL_ERROR, "Error initializing menu"));

	// nebula image
	if (!nebula.initialize(graphics,0,0,0,&nebulaTexture))
		throw(GameError(gameErrorNS::FATAL_ERROR, "Error initializing nebula"));

	// ship1
	if (!ship1.initialize(this, 116,59 , 8, &ship1_texture))
		throw(GameError(gameErrorNS::FATAL_ERROR, "Error initializing ship1"));

	ship1.setFrames(0, 7);
	ship1.setCurrentFrame(0);
	ship1.setColorFilter(SETCOLOR_ARGB(255,230,230,255));   // light blue, used for shield and torpedo
	ship1.setMass(shipNS::MASS);

	if (!torpedo_texture.initialize(graphics,"pictures\\laser.png"))
		throw(GameError(gameErrorNS::FATAL_ERROR, "Error initializing torpedo1"));


	// torpedo1
	if (!torpedo1.initialize(this, torpedoNS::WIDTH, torpedoNS::HEIGHT, 1, &torpedo_texture))
		throw(GameError(gameErrorNS::FATAL_ERROR, "Error initializing torpedo1"));

	torpedo1.setFrames(0,0);
	torpedo1.setCurrentFrame(0);
	torpedo1.setColorFilter(SETCOLOR_ARGB(255,230,230,255));   // light blue, used for shield and torpedo
	torpedo1.setMass(torpedoNS::MASS);
	// Start ships on opposite sides of planet in stable clockwise orbit


	ship1.setDegrees(-90.0f);

	ship1.setX(GAME_WIDTH/2 - shipNS::WIDTH);

	ship1.setY(400 - shipNS::HEIGHT);

	audio->playCue(ACTION_THEME);

	
	posy=0;

	count =0.2;

	return;
}

//=============================================================================
// Update all game items
//=============================================================================
void Spacewar::update()
{
	if (menuOn)
	{
		if (input->anyKeyPressed())
		{
			menuOn = false;
			input->clearAll();
			audio->playCue(GAME_PLAY);
			attack = false;
			roundStart();
		}
	} 
	 /*if(restart)
	{
		restart=false;
		roundStart();
		
	}*/
	if (input->isKeyDown(SHIP1_RIGHT_KEY))
	{
		ship1.setX(ship1.getX() + frameTime * shipNS::SPEED);
		if (ship1.getX() > GAME_WIDTH)               // if off screen right
			ship1.setX((float)-1*ship1.getWidth());

	}
	if (input->isKeyDown(SHIP1_LEFT_KEY))
	{
		ship1.setX(ship1.getX() - frameTime * shipNS::SPEED);
		if (ship1.getX() < -116)         // if off screen left
			ship1.setX((float)GAME_WIDTH);   

	}
	else if(countDownOn)
	{
		countDownTimer -= frameTime;
		if(countDownTimer <= 0)
		{
			countDownOn = false;
			start = true;

			attack = true; 
		}
	} 
	if(!menuOn)
	{
	if(s1)
	{

     count2 -= frameTime;
		if(count2 <= 0)
		{
              count3 =spacewarNS::COUNT3_DOWN;
			  show = true;
			  
			s1 = false;
			s2 = true;
		}

	}

	 if(s2)
	{
	   count3 -= frameTime;
	   AI.setX(pos - frameTime * shipNS::AI_SPEED);
		if(count3 <= 0)
		{
              count2 =spacewarNS::COUNT2_DOWN;
			  show = false;
			s1 = true;
			s2 = false;
			pos =700;
			AI.setY(0);
		}
		pos -=2;

	}

	}


	if(attack)
	{
		if (input->isKeyDown(SHIP1_FIRE_KEY))
			torpedo1.fire(&ship1);                  // fire torpedo1
	}


	// Update the entities

	ship1.update(frameTime);
	torpedo1.update(frameTime);
	AI.update(frameTime);
	if(!menuOn)
	{
		if(attack)
		{

		for(int i = 0 ; i<5;++i)
		{
			for(int j = 0 ; j <5;++j)
			{
				invad[i][j].update(frameTime);

			}
		}

		if(gameover==24)
		{
			speed =250;
		}

		if(!first)
		{
			for(int i = 0 ; i<5;++i)
			{
				for(int j = 0 ; j <5;++j)
				{
					invad[i][j].setX(invad[i][j].getX() + frameTime * speed);
				
					if(invad[i][j].getX()>650)
					{
						sec = true;
						first = true;
						break;

					}

				}
				if(sec)break;

			}
	

		}
				
		if(sec)
		{
			for(int i = 0 ; i<5;++i)
			{
				for(int j = 0 ; j <5;++j)
				{

					invad[i][j].setX(invad[i][j].getX() - frameTime * speed);
					if(invad[i][j].getX()<0)
					{
						first = false;
						sec = false;
						move++;
						break;
					}

				}

				if(!first) 
				{
					
					 int i ,j;		
					for( i = 0 ; i<5;++i)
					{

						for( j = 0 ; j <5;++j)
						{

							invad[i][j].setY((invad[i][j].getY()+posy +shipNS::HEIGHT));
                             posy +=1;
							
						}
						
						posy += 1;
						

					}
					speed +=40;
					 break;
                    
				}
                     

			}

		}


		}

	}


}

//=============================================================================

//=============================================================================
void Spacewar::roundStart()
{
	// Start ships on opposite sides of planet in stable clockwise orbit
	
	ship1.setX(GAME_WIDTH/2 - shipNS::WIDTH);

	ship1.setY(400 - shipNS::HEIGHT);

	ship1.setDegrees(-90.0f);

	countDownTimer = spacewarNS::COUNT_DOWN;

	countDownOn = true;
	start = false;
	torpedo1.setActive(false);
	roundOver = false;
	ship1Scored = false;
	ship2Scored = false;
	count2down=true;
	show =false;
	count2 = spacewarNS::COUNT2_DOWN;
	s1 = true;
	s2 = false;
	pos = 700;
}

//=============================================================================
// Artificial Intelligence
//=============================================================================
void Spacewar::ai()
{}

//=============================================================================
// Handle collisions
//=============================================================================
void Spacewar::collisions()
{
	VECTOR2 collisionVector;

	// if collision between torpedos and ships
	for(int i = 0 ; i<5;++i)
	{
		for(int j = 0 ; j <5;++j)
		{
			if(torpedo1.collidesWith(invad[i][j], collisionVector))
			{
				gameover++;
				invad[i][j].damage(TORPEDO);
				torpedo1.setVisible(false);
				torpedo1.setActive(false);


			}

		}

	}
	for(int i = 0 ; i<5;++i)
	{
		for(int j = 0 ; j <5;++j)
		{
			if(ship1.collidesWith(invad[i][j], collisionVector))
			{

				ship1.setActive(false);
				torpedo1.setVisible(false);
				torpedo1.setActive(false);

				roundOver=true;
				return ;
			}

		}

	}

	// check for scores



}

//=============================================================================
// Render game items
//=============================================================================
void Spacewar::render()
{
	graphics->spriteBegin();                // begin drawing sprites

	nebula.draw();                          // display Orion nebula
	// draw the planet

	ship1.draw();                           // draw the spaceships

	torpedo1.draw();      // draw the torpedoes using colorFilter

	if(!menuOn)
	{
		for(int i = 0 ; i<5;++i)
		{
			for(int j = 0 ; j <5;++j)
			{
				invad[i][j].draw();

			}
		}

	}
	if(roundOver)
	{
		game.draw();
		s1 = false;
		s2 = false;
		show = false;
		attack = false;
		/*_snprintf_s(buffer, spacewarNS::BUF_SIZE, "Your Score is :%d", (int)(ceil(countDownTimer)));
		fontBig.print(buffer,spacewarNS::COUNT_DOWN_X,spacewarNS::COUNT_DOWN_Y);
		*/
	}
	/*if(ship1Scored)
	game.draw();*/
	if(gameover==25)
	{
		Victory.draw();
		s1 = false;
		s2 = false;
		show = false;
		attack = false;
		restart=true;
	}
	if(!menuOn && show)
	{
	fontScore.setFontColor(spacewarNS::SCORE_COLOR);
	_snprintf_s(buffer, spacewarNS::BUF_SIZE, "Score:%d", (int)gameover);
	fontScore.print(buffer,spacewarNS::SCORE1_X,spacewarNS::SCORE_Y);
	AI.draw();

	}

	if(menuOn)
	{
		menu.draw();

	}
	if(countDownOn)
	{
		_snprintf_s(buffer, spacewarNS::BUF_SIZE, "%d", (int)(ceil(countDownTimer)));
		fontBig.print(buffer,spacewarNS::COUNT_DOWN_X,spacewarNS::COUNT_DOWN_Y);

	}

	graphics->spriteEnd();                  // end drawing sprites
}

//=============================================================================
// process console commands
// We will use it during the game
//=============================================================================
void Spacewar::consoleCommand()
{
	// The music control is located here because consoleCommand is always called,
	// even if the game is paused.
	if(paused || musicOff)
		audio->pauseCategory("Music");
	else
		audio->resumeCategory("Music");

	command = console->getCommand();    // get command from console
	if(command == "")                   // if no command
		return;

	if (command == "help")              // if "help" command
	{
		console->print("Console Commands:");
		console->print("fps - toggle display of frames per second");
	
		console->print("music on - plays music");
		console->print("music off - no music");
		return;
	}
	if (command == "fps")
	{
		fpsOn = !fpsOn;                 // toggle display of fps
		if(fpsOn)
			console->print("fps On");
		else
			console->print("fps Off");
	}

	if (command == "gravity off")
	{
		planet.setMass(0);
		console->print("Gravity Off");
	}

	
	else if (command == "music off")
	{
		musicOff = true;
		console->print("Music Off");
	}
	else if (command == "music on")
	{
		musicOff = false;
		console->print("Music On");
	}
}

//=============================================================================
// The graphics device was lost.
// Release all reserved video memory so graphics device may be reset.
//=============================================================================
void Spacewar::releaseAll()
{
	menuTexture.onLostDevice();
	nebulaTexture.onLostDevice();
	ship1_texture.onLostDevice();
	//invad_text.onLostDevice();
	gameTextures.onLostDevice();
	fontScore.onLostDevice();
	fontBig.onLostDevice();
	torpedo_texture.onLostDevice();
	gameOver.onLostDevice();
	Victory_Text.onLostDevice();

	Game::releaseAll();
	return;
}

//=============================================================================
// The grahics device has been reset.
// Recreate all surfaces.
//=============================================================================
void Spacewar::resetAll()
{
	gameOver.onResetDevice();
	fontBig.onResetDevice();
	fontScore.onResetDevice();
	ship1_texture.onResetDevice();
	//invad_text.onResetDevice();
	torpedo_texture.onResetDevice();
	gameTextures.onResetDevice();
	nebulaTexture.onResetDevice();
	menuTexture.onResetDevice();
	Victory_Text.onResetDevice();

	Game::resetAll();
	return;
}
