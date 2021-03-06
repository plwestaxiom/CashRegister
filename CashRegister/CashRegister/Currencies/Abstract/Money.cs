﻿using System;

namespace CashRegisterConsumer
{
    public abstract class Money : IComparable
    {
        private int _count;

        private readonly decimal _denomination;
        private readonly string _singleName;
        private readonly string _pluralName;

        public decimal Denomination { get { return _denomination; } }
        public string Name { get { return (_count == 1) ? _singleName : _pluralName; } }
        public int Count { get { return _count; } }

        public Money(decimal denomination, string singleName, string pluralName)
        {
            this._denomination = denomination;
            this._singleName = singleName;
            this._pluralName = pluralName;
            this._count = 0;
        }

        public Money(decimal denomination, string singleName, string pluralName, int count) : this(denomination, singleName, pluralName)
        {
            this._count = count;
        }

        public void Add(int count)
        {
            _count += count;
        }

        public void Subtract(int count)
        {
            _count -= count;
        }

        public void Clear()
        {
            _count = 0;
        }

        /// <summary>
        /// IComparable override. Used for sorting and reversing the currency to ensure the list of Money is
        /// from largest denomination to smallest.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(object other)
        {
            if (other == null) return 1;

            Money otherMoney = other as Money;
            if (otherMoney != null)
                return this._denomination.CompareTo(otherMoney._denomination);
            else
                throw new ArgumentException("Object is not Money");
        }
    }
}