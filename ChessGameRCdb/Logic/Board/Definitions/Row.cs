﻿using ChessGame.Logic;
using System;

namespace ChessGame.Logic
{
    public class Row : Enumeration
    {
        public static Row One   = new Row(1, nameof(One));
        public static Row Two   = new Row(2, nameof(Two));
        public static Row Three = new Row(3, nameof(Three));
        public static Row Four  = new Row(4, nameof(Four));
        public static Row Five  = new Row(5, nameof(Five));
        public static Row Six   = new Row(6, nameof(Six));
        public static Row Seven = new Row(7, nameof(Seven));
        public static Row Eight = new Row(8, nameof(Eight));

        public static Row Max = Eight;
        public static Row Min = One;

        public Row(int id, string name) : base(id, name) { }

        public static bool Validate(int r) => r >= Min.Id && r <= Max.Id;

        public static Row operator +(Row left, int right)
        {
            if (left.Id + right > Eight.Id) return null;
            return FromValue<Row>(left.Id + right);
        }
        public static Row operator -(Row left, int right)
        {
            if (left.Id - right < One.Id) return null;
            return FromValue<Row>(left.Id - right);
        }
        public static Row operator ++(Row origin)
        {
            if (origin == Eight) return null;
            return FromValue<Row>(origin.Id + 1);
        }
        public static Row operator --(Row origin)
        {
            if (origin == One) return null;
            return FromValue<Row>(origin.Id - 1);
        }
        public static bool operator >=(Row left, Row rigth)
        {
            return left.Id >= rigth.Id;
        }
        public static bool operator <=(Row left, Row rigth)
        {
            return left.Id <= rigth.Id;
        }
        public static bool operator >(Row left, Row rigth)
        {
            return left.Id > rigth.Id;
        }
        public static bool operator <(Row left, Row rigth)
        {
            return left.Id < rigth.Id;
        }
    }
}
