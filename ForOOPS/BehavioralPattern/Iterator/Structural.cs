﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForOOPS.BehavioralPattern.Iterator
{
    /// <summary>

    /// MainApp startup class for Structural 

    /// Iterator Design Pattern.

    /// </summary>

    class Structural

    {
        /// <summary>

        /// Entry point into console application.

        /// </summary>

        void Main()
        {
            ConcreteAggregate a = new ConcreteAggregate();
            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";

            // Create Iterator and provide aggregate

            Iterator1 i = a.CreateIterator();

            Console.WriteLine("Iterating over collection:");

            object item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>

    /// The 'Aggregate' abstract class

    /// </summary>

    abstract class Aggregate

    {
        public abstract Iterator1 CreateIterator();
    }

    /// <summary>

    /// The 'ConcreteAggregate' class

    /// </summary>

    class ConcreteAggregate : Aggregate

    {
        private ArrayList _items = new ArrayList();

        public override Iterator1 CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        // Gets item count

        public int Count
        {
            get { return _items.Count; }
        }

        // Indexer

        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }

    /// <summary>

    /// The 'Iterator' abstract class

    /// </summary>

    abstract class Iterator1

    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    /// <summary>

    /// The 'ConcreteIterator' class

    /// </summary>

    class ConcreteIterator : Iterator1

    {
        private ConcreteAggregate _aggregate;
        private int _current = 0;

        // Constructor

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this._aggregate = aggregate;
        }

        // Gets first iteration item

        public override object First()
        {
            return _aggregate[0];
        }

        // Gets next iteration item

        public override object Next()
        {
            object ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }

        // Gets current iteration item

        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        // Gets whether iterations are complete

        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }



}
