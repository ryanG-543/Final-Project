using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Final_Project
{
    class CollisionManager
    {       
        private PlayerManager playerManager;
        private EnemyManager enemyManager;        
        private Vector2 offScreen = new Vector2(-500, -500);       
        private int enemyPointValue = 25;       
       

        public CollisionManager(            
            PlayerManager playerManager,
            EnemyManager EnemyManager)          
              
        {            
            this.playerManager = playerManager;
            this.enemyManager = EnemyManager;           
        }

        private void checkShotToEnemyCollisions()
        {
            foreach (Sprite shot in playerManager.PlayerShotManager.Shots)
            {
                foreach (Enemy enemy in enemyManager.Enemies)
                {
                    if (shot.IsCircleColliding(
                        enemy.EnemySprite.Center,
                        enemy.EnemySprite.CollisionRadius))
                    {
                        shot.Location = offScreen;
                        enemy.Destroyed = true;
                        playerManager.PlayerScore += enemyPointValue;
                        
                    }

                }
            }
        }      

        private void checkShotToPlayerCollisions()
        {
            foreach (Sprite shot in enemyManager.EnemyShotManager.Shots)
            {
                if (shot.IsCircleColliding(
                    playerManager.playerSprite.Center,
                    playerManager.playerSprite.CollisionRadius))
                {
                    shot.Location = offScreen;                    
                    
                }
            }
        }

        private void checkEnemyToPlayerCollisions()
        {
            foreach (Enemy enemy in enemyManager.Enemies)
            {
                if (enemy.EnemySprite.IsCircleColliding(
                    playerManager.playerSprite.Center,
                    playerManager.playerSprite.CollisionRadius))
                {
                    enemy.Destroyed = true;
                    

                    

                    //                    explosionManager.AddExplosion(
                    //                        playerManager.playerSprite.Center,
                    //                        Vector2.Zero);
                }
            }
        }            
        public void CheckCollisions()
        {
            checkShotToEnemyCollisions();                       
            if (!playerManager.Destroyed)
            {
                checkShotToPlayerCollisions();
                checkEnemyToPlayerCollisions();                              
            }
        }

    }
}
