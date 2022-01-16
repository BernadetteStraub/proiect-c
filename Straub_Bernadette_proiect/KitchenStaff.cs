using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Threading;

namespace Straub_Bernadette_proiect
{
    class KitchenStaff : Component
    {

        public KitchenStaff()
        {
            InitializeComponent();
        }

        private DishType mDishType;

        public DishType DishType
        {
            get
            {
                return mDishType;
            }
            set
            {
                mDishType = value;
            }
        }

        private System.Collections.ArrayList mDishes = new System.Collections.ArrayList();
        public Dish this[int Index]
        {
            get
            {
                return (Dish)mDishes[Index];

            }
            set
            {
                mDishes[Index] = value;
            }
        }

        public delegate void DishCompleteDelegate();
        public event DishCompleteDelegate DishComplete;

        DispatcherTimer dishTimer;

        private void InitializeComponent()
        {
            this.dishTimer = new DispatcherTimer();
            this.dishTimer.Tick += new System.EventHandler(this.dishTimer_Tick);
        }

        private void dishTimer_Tick(object sender, EventArgs e)
        {
            Dish aDish = new Dish(this.DishType);
            mDishes.Add(aDish);
            DishComplete();
        }

        public bool Enabled
        {
            set
            {
                dishTimer.IsEnabled = value;
            }
        }
        public int Interval
        {
            set
            {
                dishTimer.Interval = new TimeSpan(0, 0, value);
            }
        }

        public void PrepareDishes(DishType dType)
        {

            DishType = dType;
            switch (DishType)
            {
                case DishType.Bolognese: Interval = 15; break;
                case DishType.Carbonara: Interval = 16; break;
                case DishType.Pesto: Interval = 14; break;
                case DishType.Margherita: Interval = 13; break;
                case DishType.Tonno: Interval = 15; break;
                case DishType.Diavola: Interval = 14; break;
                case DishType.Gelato: Interval = 2; break;
                case DishType.Tiramisu: Interval = 5; break;
            }
            dishTimer.Start();
        }

    }

    public enum DishType
    {
        Bolognese,
        Carbonara,
        Pesto,
        Margherita,
        Tonno,
        Diavola,
        Gelato,
        Tiramisu
    }

    class Dish
    {
        private DishType mDishType;

        public DishType DishType
        {
            get
            {
                return mDishType;
            }
            set
            {
                mDishType = value;
            }
        }

        private float mPrice = .50F;
        public float Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }

        private readonly DateTime mTimeOfCreation;
        public DateTime TimeOfCreation
        {
            get
            {
                return mTimeOfCreation;
            }

        }

        public Dish(DishType aDishType)
        {
            mTimeOfCreation = DateTime.Now;
            mDishType = aDishType; 
        }
    }
}
