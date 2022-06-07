using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameController
{
    public static bool player1_status { get; set; }
    public static bool player2_status { get; set; }

    public static bool axe_p1_status { get; set; }
    public static bool axe_p2_status { get; set; }
    public static bool pickaxe_p1_status { get; set; }
    public static bool pickaxe_p2_status { get; set; }

    public static bool axe_animate { get; set; }
    public static bool pickaxe_animate { get; set; }

    public static bool wood_player1_status { get; set; }
    public static bool wood_player2_status { get; set; }
    public static bool iron_player1_status { get; set; }
    public static bool iron_player2_status { get; set; }

    public static bool craftedrail_player1_status { get; set; }
    public static bool craftedrail_player2_status { get; set; }

    public static bool wood_on_anvil { get; set; }
    public static bool iron_on_anvil { get; set; }

    public static bool tools_status { get; set; }

    public static bool destroy_material { get; set; }
}
