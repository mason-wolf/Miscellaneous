#include <SDL.h>
#include <stdio.h>
#include <string>


const int SCREEN_WIDTH = 640;
const int SCREEN_HEIGHT = 480;

enum KeyPressSurfaces
{
	KEY_PRESS_SURFACE_DEFAULT,
	KEY_PRESS_SURFACE_UP,
	KEY_PRESS_SURFACE_DOWN,
	KEY_PRESS_SURFACE_LEFT,
	KEY_PRESS_SURFACE_RIGHT,
	KEY_PRESS_SURFACE_TOTAL
};

void init();
void loadMedia();
void close();


SDL_Surface* loadSurface( std::string path );
SDL_Window* gWindow = NULL;
SDL_Surface* gScreenSurface = NULL;
SDL_Surface* gKeyPressSurfaces[ KEY_PRESS_SURFACE_TOTAL ];
SDL_Surface* gCurrentSurface = NULL;

void init()
{
		gWindow = SDL_CreateWindow( "", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, SCREEN_WIDTH, SCREEN_HEIGHT, SDL_WINDOW_SHOWN );
		gScreenSurface = SDL_GetWindowSurface( gWindow );
}

void loadMedia()
{
	gKeyPressSurfaces[ KEY_PRESS_SURFACE_DEFAULT ] = loadSurface("default.bmp");
	gKeyPressSurfaces[ KEY_PRESS_SURFACE_UP ] = loadSurface("up.bmp");
	gKeyPressSurfaces[ KEY_PRESS_SURFACE_DOWN ] = loadSurface("down.bmp");
	gKeyPressSurfaces[ KEY_PRESS_SURFACE_LEFT ] = loadSurface("left.bmp");
	gKeyPressSurfaces[ KEY_PRESS_SURFACE_RIGHT ] = loadSurface("right.bmp");
}

SDL_Surface* loadSurface( std::string path )
{
	SDL_Surface* loadedSurface = SDL_LoadBMP( path.c_str() );
	return loadedSurface;
}

void close()
{
	for(int i = 0; i < KEY_PRESS_SURFACE_TOTAL; ++i)
	{
		SDL_FreeSurface(gKeyPressSurfaces[i]);
		gKeyPressSurfaces[i] = NULL;
	}
	SDL_DestroyWindow(gWindow);
	gWindow = NULL;
	SDL_Quit();
}

int main( int argc, char* args[] )
{
			init();
			loadMedia();
			bool quit = false;
			SDL_Event e;
			gCurrentSurface = gKeyPressSurfaces[ KEY_PRESS_SURFACE_DEFAULT ];
			while( !quit )
			{
				while( SDL_PollEvent( &e ) != 0 )
				{
					if( e.type == SDL_QUIT )
					{
						quit = true;
					}
					else if( e.type == SDL_KEYDOWN )
					{
						switch( e.key.keysym.sym )
						{
							case SDLK_UP:
							gCurrentSurface = gKeyPressSurfaces[ KEY_PRESS_SURFACE_UP ];
							break;

							case SDLK_DOWN:
							gCurrentSurface = gKeyPressSurfaces[ KEY_PRESS_SURFACE_DOWN ];
							break;

							case SDLK_LEFT:
							gCurrentSurface = gKeyPressSurfaces[ KEY_PRESS_SURFACE_LEFT ];
							break;

							case SDLK_RIGHT:
							gCurrentSurface = gKeyPressSurfaces[ KEY_PRESS_SURFACE_RIGHT ];
							break;

							default:
							gCurrentSurface = gKeyPressSurfaces[ KEY_PRESS_SURFACE_DEFAULT ];
							break;
						}
					}
				}
				SDL_BlitSurface( gCurrentSurface, NULL, gScreenSurface, NULL );
				SDL_UpdateWindowSurface( gWindow );
			}
	close();
	return 0;
}
