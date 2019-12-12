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
        if(name[0]=='a'){
            throw new System.ArgumentException("pas de nom commençant par a");
        }
        if(name[0]=='A'){
            throw new System.ArgumentException("pas de nom commençant par A");
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
        if(capacity<1){
            throw new System.ArgumentException("la capacité ne peut être inférieur à 1");
        }
        }

        public bool IsEmpty() {
            if(capacity==0){
                return true;
            }
            if(capacity<=1){
                return true;
            }
            return false;
        }

        public bool IsFull() {
            if(capacity>currentAmount){
            return true;
            }
            return false;
        }

        public void Store(int amount) {
            if(capacity<(currentAmount+10)){
             currentAmount+=amount; 
             }
             if(amount==0)  throw new System.ArgumentException("on ne peut ajouter 0");
            
             else  throw new System.ArgumentException("le panier est plein");       
        }

        public void Withdraw(int amount) {
            var amountCurrent = this.CurrentAmount - amount;
            if (amount <0 ){
                throw new dark_place_game.CantWithDrawMoreThanCurrentAmountExeption();
            }
            if (amount==0){
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
