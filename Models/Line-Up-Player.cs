﻿namespace WMBA_7_2_.Models
{
    public class Line_Up_Player
    {
        public int ID { get; set; }


        public int PlayerID { get; set; }
        public Player Player { get; set; }


        public int Line_UpID { get; set; }
		public Line_Up Line_Up { get; set; }

	}
}
