using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

namespace TheLoops
{
    public class TheLoopRoom : MonoBehaviour
    {
        [Header("--------------------------RoomInfo------------------------")]
        public int CurrentRoomNo=0;

        [Header("--------------------------RoomTask------------------------")]
        [SerializeField]private RoomTasks roomTasks;
        [SerializeField]private TaskCollider taskCollider;
        [SerializeField]private Transform[] TaskSpawnLocation;
        [SerializeField]private Sprite TaskSprite;

        private enum RoomTasks{
            LookLeft,
            LookRight,
            SorryIMeanRight,
            YouAreDead,
        }

        private enum TaskCollider{
            LookLeftCollider,
            LookRightCollider,
            SorryIMeanRightCollider,
        }


        void Start()
        {

        }

        void Update()
        {

        }
    }
}

