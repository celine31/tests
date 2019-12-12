using System;
using Xunit;

namespace dark_place_game.tests
{
    
    /// Cette classe contient tout un ensemble de tests unitaires pour la classe CurrencyHolder
    public class CurrencyHolderTest
    {
        public static readonly int EXEMPLE_CAPACITE_VALIDE = 2748;
        public static readonly int EXEMPLE_CONTENANCE_INITIALE_VALIDE = 978;
        public static readonly string EXEMPLE_NOM_MONNAIE_VALIDE = "Brouzouf";

        
        [Fact]
        public void VraiShouldBeTrue()
        {
            var vrai = true;
            Assert.True(vrai, "Erreur, vrai vaut false. Le test est volontairement mal écrit, corrigez le.");
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf10ShouldContain10Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , 10);
            var result = ch.CurrentAmount == 10;
            Assert.True(result);
        }

        //methode ne pas ajouter 0
         [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf0ShouldContain10Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , 0);
            var result = ch.CurrentAmount == 0;
            Assert.True(result);
        }

        //methode ne pas ajouter de quantite negative a modifier
        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOfNegatifShouldContain10Currency()
        {
             Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , -1);
             Assert.Throws<ArgumentException>(mauvaisAppel);
        }


        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf25ShouldContain25Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 25);
            var result = ch.CurrentAmount == 25;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf0ShouldContain0Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE, 0);
            var result = ch.CurrentAmount == 0;
            Assert.True(result);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNegativeContentThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , -10);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNullNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(null,EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithEmptyNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder("",EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        //#TODO_ETAPE_4
        [Fact]
        public void BrouzoufIsAValidCurrencyName ()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Brouzouf
            var ch = new CurrencyHolder("Brouzouf",EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            var result = ch.CurrencyName == "Brouzouf";
            Assert.True(result);
        }

        //methode commençant pas a
        [Fact]
        public void asaInvalidCurrencyName ()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Brouzouf
            Action mauvaisAppel = () => new CurrencyHolder("adollard",EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        //methode commençant pas A
        [Fact]
        public void asAInvalidCurrencyName ()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Brouzouf
            Action mauvaisAppel = () => new CurrencyHolder("Adollard",EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Dollard
        [Fact]
        public void DollardIsAValidCurrencyName ()
        {
            var ch = new CurrencyHolder("Dollard",EXEMPLE_CAPACITE_VALIDE, 0);
            var result = ch.CurrencyName == "Dollard";
            Assert.True(result);
       
        }

        //IsEmpty
       [Fact]
        public void TestIsEmpty()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac a moité plein, il contient maintenant la bonne quantité de currency
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 480, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            ch.Store(20);
            Assert.True(ch.IsEmpty());
        }


//TODO a modifier
       [Fact]
        public void TestPut10CurrencyInNonFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac a moité plein, il contient maintenant la bonne quantité de currency
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 480);
            ch.Store(10);
            Assert.True(ch.CurrentAmount == 490);
        }
// methode pour verifier si panier plein on ne peut ajouter
        [Fact]
        public void TestPut10CurrencyInNearlyFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac quasiement plein, une exeption NotEnoughtSpaceInCurrencyHolderExeption est levée.
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 500, 490);
                ch.Store(20);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

       
        [Fact]
        public void CreatingCurrencyHolderWithNameShorterThan4CharacterThrowExeption()
        {
            // A vous d'écrire un test qui doit échouer s'il es possible de créer un CurrencyHolder dont Le Nom De monnaie est inférieur a 4 lettres
          Action mauvaisAppel = () => new CurrencyHolder("Bro",EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
         Assert.Throws<ArgumentException>(mauvaisAppel);
        }
        
        // nom supperieur a 10 avec exemple de 12
         [Fact]
        public void CreatingCurrencyHolderWithNameBiggerThan10CharacterThrowExeption()
        {
          Action mauvaisAppel = () => new CurrencyHolder("Brouzoufffff",EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
         Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void WithdrawMoreThanCurrentAmountInCurrencyHolderThrowExeption()
        {
            // A vous d'écrire un test qui vérifie que retirer (methode withdraw) une quantité negative de currency leve une exeption CantWithDrawNegativeCurrencyAmountExeption.
            // Asruce : dans ce cas prévu avant même de pouvoir compiler le test, vous allez être obligé de créer la classe CantWithDrawMoreThanCurrentAmountExeption (vous pouvez la mettre dans le meme fichier que CurrencyHolder)
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 250, 200);
                ch.Withdraw(-60);
            };
            Assert.Throws<dark_place_game.CantWithDrawMoreThanCurrentAmountExeption>(mauvaisAppel);
        }
    //methode on ne peut enlever 0
        [Fact]
        public void WithdrawMoreThanCurrentAmount0InCurrencyHolderThrowExeption()
        {
            // A vous d'écrire un test qui vérifie que retirer (methode withdraw) une quantité 0 de currency leve une exeption CantWithDrawNegativeCurrencyAmountExeption.
            // Asruce : dans ce cas prévu avant même de pouvoir compiler le test, vous allez être obligé de créer la classe CantWithDrawMoreThanCurrentAmountExeption (vous pouvez la mettre dans le meme fichier que CurrencyHolder)
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 250, 200);
                ch.Withdraw(0);
            };
            Assert.Throws<dark_place_game.CantWithDrawMoreThanCurrentAmountExeption>(mauvaisAppel);
        }
    
    }
       

    }
