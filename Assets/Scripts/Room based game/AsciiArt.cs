//using UnityEngine;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GD12_1133_A2_SreejaYathipathi
//{
//    public class AsciiArt
//    {
//        // Welcome art.
//        public void Welcome()
//        {
//            Debug.Log("Welcom to \r\n");
//            Debug.Log("╔══════════════════════════════════════════════════════════════════════════════════════╗\r\n" +
//                              "║                                                                                      ║\r\n" +
//                              "║  ▓█████▄ ▓█████ ▄▄▄     ▄▄▄█████▓ ██░ ██         ▄████  ▄▄▄       ███▄ ▄███▓▓█████   ║\r\n" +
//                              "║  ▒██▀ ██▌▓█   ▀▒████▄   ▓  ██▒ ▓▒▓██░ ██▒       ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀   ║\r\n" +
//                              "║  ░██   █▌▒███  ▒██  ▀█▄ ▒ ▓██░ ▒░▒██▀▀██░      ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███     ║\r\n" +
//                              "║  ░▓█▄   ▌▒▓█  ▄░██▄▄▄▄██░ ▓██▓ ░ ░▓█ ░██       ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄   ║\r\n" +
//                              "║  ░▒████▓ ░▒████▒▓█   ▓██▒ ▒██▒ ░ ░▓█▒░██▓      ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒  ║\r\n" +
//                              "║   ▒▒▓  ▒ ░░ ▒░ ░▒▒   ▓▒█░ ▒ ░░    ▒ ░░▒░▒       ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░  ║\r\n" +
//                              "║   ░ ▒  ▒  ░ ░  ░ ▒   ▒▒ ░   ░     ▒ ░▒░ ░        ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░  ║\r\n" +
//                              "║   ░ ░  ░    ░    ░   ▒    ░       ░  ░░ ░      ░ ░   ░   ░   ▒   ░      ░      ░     ║\r\n" +
//                              "║     ░       ░  ░     ░  ░         ░  ░  ░            ░       ░  ░       ░      ░  ░  ║\r\n" +
//                              "║   ░                                                                                  ║\r\n" +
//                              "║                                                                                      ║\r\n" +
//                              "╚══════════════════════════════════════════════════════════════════════════════════════╝");
//        }

//        // Rules
//        public void About()
//        {
//            Debug.Log("\nThese are the rules of the game.");
//            Debug.Log("\nPress enter to continue the rules");
//            Debug.Log("\nPlayer can select how many rooms they want to play from 6, 8, 10");
//            Debug.Log("\nThere are total three type of rooms.");
//            Debug.Log("\n1 - Treasure Room");
//            Debug.Log("\n2 - Normal Room");
//            Debug.Log("\n3 - Combat Room");
//            Debug.Log("\nIn Tresure Room, you can search for tresure chest.");
//            Debug.Log("\nTreasure Chest consists of 2 to 4 items, which can be Long Sword, Dagger, Polearm, Small Healing Potion, Medium Healing Potion, Large Healing Potion.");
//            Debug.Log("\nYou can either pick it or leave it.");
//            Debug.Log("\nIn Normal Room, you can find any of one or two items if you search for it.");
//            Debug.Log("\nIn Combat Room, you can't exit unless you have defeated the boss.");
//            Debug.Log("\nYou can choose a weapon from your inventory. Each weapon have different type of damage");
//            Debug.Log("\nLong sword - High damage");
//            Debug.Log("\nPolearm - medium damage");
//            Debug.Log("\nDagger - medium-low damage");
//            Debug.Log("\nYou can press keys aor attacking.");
//            Debug.Log("\nZ - High damage");
//            Debug.Log("\nX - Medium damage");
//            Debug.Log("\nC - Low damage");
//            Debug.Log("\nSmall healing potion restores 25% health.");
//            Debug.Log("\nMedium healing potion restores 50% health.");
//            Debug.Log("\nLarge healing potion restores 100% health.");
//            Debug.Log("\nIf you died, you are out of the game. You can select if you want to play again or not.");
//        }

//        // Died art
//        public void Died()
//        {
//            Debug.Log("╔═════════════════════════════════════════════════════════════╗\r\n" +
//                                      "║                                                             ║\r\n" +
//                                      "║  ▓██   ██▓ ▒█████   █    ██    ▓█████▄  ██▓▓█████ ▓█████▄   ║\r\n" +
//                                      "║   ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▒██▀ ██▌▓██▒▓█   ▀ ▒██▀ ██▌  ║\r\n" +
//                                      "║    ▒██ ██░▒██░  ██▒▓██  ▒██░   ░██   █▌▒██▒▒███   ░██   █▌  ║\r\n" +
//                                      "║    ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░▓█▄   ▌░██░▒▓█  ▄ ░▓█▄   ▌  ║\r\n" +
//                                      "║    ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░▒████▓ ░██░░▒████▒░▒████▓   ║\r\n" +
//                                      "║     ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ▒▒▓  ▒ ░▓  ░░ ▒░ ░ ▒▒▓  ▒   ║\r\n" +
//                                      "║   ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░     ░ ▒  ▒  ▒ ░ ░ ░  ░ ░ ▒  ▒   ║\r\n" +
//                                      "║   ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░     ░ ░  ░  ▒ ░   ░    ░ ░  ░   ║\r\n" +
//                                      "║   ░ ░         ░ ░     ░           ░     ░     ░  ░   ░      ║\r\n" +
//                                      "║   ░ ░                           ░                  ░        ║\r\n" +
//                                      "║                                                             ║\r\n" +
//                                      "╚═════════════════════════════════════════════════════════════╝");
//        }

//        // Gameover art
//        public void GameOver()
//        {
//            Debug.Log("╔═════════════════════════════════════════════════════════════════════════════╗\r\n" +
//                                      "║                                                                             ║\r\n" +
//                                      "║    ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███    ║\r\n" +
//                                      "║   ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒  ║\r\n" +
//                                      "║  ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒  ║\r\n" +
//                                      "║  ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄    ║\r\n" +
//                                      "║  ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒  ║\r\n" +
//                                      "║   ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░  ║\r\n" +
//                                      "║    ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░  ║\r\n" +
//                                      "║  ░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░   ║\r\n" +
//                                      "║        ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░       ║\r\n" +
//                                      "║                                                       ░                     ║\r\n" +
//                                      "║                                                                             ║\r\n" +
//                                      "╚═════════════════════════════════════════════════════════════════════════════╝");
//        }
//    }
//}
