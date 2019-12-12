using System;

namespace dark_place_game
{

    [System.Serializable]
    /// Une Exeption Custom
    public class NotEnoughtSpaceInCurrencyHolderExeption : System.Exception { }
    public class CanWitchDrawMoreThanCurrentAmountException : System.Exception { }


    public class CurrencyHolder
    {
        public static readonly string CURRENCY_DEFAULT_NAME = "Unnamed";

        /// Le nom de la monnaie
        public string CurrencyName
        {
            get { return currencyName; }
            private set
            {
                currencyName = value;
            }
        }
        // Le champs interne de la property
        private string currencyName = CURRENCY_DEFAULT_NAME;

        /// Le montant actuel
        public int CurrentAmount
        {
            get { return currentAmount; }
            set
            {
                currentAmount = value;
            }
        }
        // Le champs interne de la property
        private int currentAmount = 0;

        /// La contenance maximum du conteneur
        public int Capacity
        {
            get { return capacity; }
            private set
            {
                capacity = value;
            }
        }
        // Le champs interne de la property
        private int capacity = 0;

        public CurrencyHolder(string name, int capacity, int amount)
        {
            if (amount < 0 || amount > capacity)
            {
                throw new System.ArgumentException("Argument invalide");
            }
            if (Equals(name, "") || (Equals(name,null)) || name.Length < 4 || name.Length > 10 || name[0] == 'a' || name[0] == 'A')
            {
                throw new System.ArgumentException("Argument invalide");
            }
            if (capacity < 0)
            {
                throw new System.ArgumentException("Argument invalide");
            }



            Capacity = capacity;
            CurrencyName = name;
            CurrentAmount = amount;

        }

        public bool IsEmpty(int amount)
        {
            if (amount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IsFull()
        {
            if (this.CurrentAmount == this.Capacity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool verifCreatingCurrency4or10NameThrowExeption()
        {
            return true;
        }

        public void Store(int amount)
        {
            if (currentAmount + amount <= capacity && amount != 0)
                currentAmount += amount;
            else
                throw new NotEnoughtSpaceInCurrencyHolderExeption();
        }
        public void Withdraw(int amount)
        {
            if (currentAmount >= amount && amount != 0)
                currentAmount -= amount;
            else
                throw new CanWitchDrawMoreThanCurrentAmountException();
        }


    }
}