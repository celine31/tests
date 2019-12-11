using System;

namespace dark_place_game
{

    [System.Serializable]
    /// Une Exeption Custom
    public class NotEnoughtSpaceInCurrencyHolderExeption : System.Exception {}

    public class CurrencyHolder
    {
        public static readonly string CURRENCY_DEFAULT_NAME = "Unnamed";

        /// Le nom de la monnaie
        public string CurrencyName {
            get {return currencyName;}
            private set {
               currencyName = value;
               }
        }
        // Le champs interne de la property
        private string currencyName = CURRENCY_DEFAULT_NAME;

        /// Le montant actuel
        public int CurrentAmount {
            get {return currentAmount;}
            private set {
                currentAmount = value;
            }
        }
        
        // Le champs interne de la property
        private int currentAmount = 0;

        /// La contenance maximum du conteneur
        public int Capacity {
            get {return capacity;}
            private set {
                capacity = value;
            }
        }
        // Le champs interne de la property
        private int capacity = 0;

        public CurrencyHolder(string name,int capacity, int amount) {
            Capacity = capacity;
            CurrencyName = name;
            CurrentAmount = amount;
        if(amount<0){
            throw new System.ArgumentException("pas de negatif");
        }
        if(name==null){
            throw new System.ArgumentException("pas de valeur null");
        }
        if(name==""){
            throw new System.ArgumentException("pas de chaine vide");
        }
        if(name.Length<4){
            throw new System.ArgumentException("pas de chaine inférieur à 4 caractères");
        }
        if(name.Length>10){
            throw new System.ArgumentException("pas de chaine supérieur a 10 caractères");
        }
        if(amount>capacity){
            throw new System.ArgumentException("le panier est plein");
        }
        }

        public bool IsEmpty() {
            return true;
        }

        public bool IsFull() {
            return true;
        }

        public void Store(int amount) {
            if(capacity<(currentAmount+10)){
             currentAmount+=amount; 
             }
            throw new System.ArgumentException("le panier est plein");       
        }

        public void Withdraw(int amount) {
            var amountCurrent = this.CurrentAmount - amount;
            if (amount <0 ){
                throw new dark_place_game.CantWithDrawMoreThanCurrentAmountExeption();
            }
            this.currentAmount -= amount;
        }
    }
    public class CantWithDrawMoreThanCurrentAmountExeption : System.Exception {
        public CantWithDrawMoreThanCurrentAmountExeption()
        :base ("message de mon exception") {}

        public CantWithDrawMoreThanCurrentAmountExeption(string message)
        :base(message) {}
        
    }
}
