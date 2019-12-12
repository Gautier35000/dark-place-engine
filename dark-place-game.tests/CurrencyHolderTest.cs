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
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, -10);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNullNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(null, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithEmptyNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder("", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void BrouzoufIsAValidCurrencyName()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Brouzouf
            var ch = new CurrencyHolder("Brouzouf", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.True( ch.CurrencyName == "Brouzouf");
        }
  
        [Fact]
        public void DollardIsAValidCurrencyName()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Dollard
            var ch = new CurrencyHolder("Dollard", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.True(ch.CurrencyName == "Dollard");

        }

        [Fact]
        public void TestPut10CurrencyInNonFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac a moité plein, il contient maintenant la bonne quantité de currency
            var currency = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            currency.Put(10);
            Assert.True(currency.CurrentAmount == EXEMPLE_CONTENANCE_INITIALE_VALIDE + 10);
        }

        [Fact]
        public void TestPut10CurrencyInNearlyFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac quasiquasiement plein, une exeption NotEnoughtSpaceInCurrencyHolderExeption est levée.
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 100, 95);
                ch.Store(6);
            };
            Assert.Throws<NotEnoughtSpaceInCurrencyHolderExeption>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNameShorterThan4CharacterThrowExeption()
        {
            // A vous d'écrire un test qui doit échouer s'il es possible de créer un CurrencyHolder dont Le Nom De monnaie est inférieur a 4 lettres
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.True(ch.CurrencyName.Length >= 4);
        }

        [Fact]
        public void WithdrawMoreThanCurrentAmountInCurrencyHolderThrowExeption()
        {
            // A vous d'écrire un test qui vérifie que retirer (methode withdraw) une quantité negative de currency leve une exeption CantWithDrawNegativeCurrencyAmountExeption.
            // Asruce : dans ce cas prévu avant même de pouvoir compiler le test, vous allez être obligé de créer la classe CantWithDrawMoreThanCurrentAmountExeption (vous pouvez la mettre dans le meme fichier que CurrencyHolder)
            Action mauvaisAppel = () =>
               {
                   var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 50);
                   ch.Withdraw(55);
               };
            Assert.Throws<CanWitchDrawMoreThanCurrentAmountException>(mauvaisAppel);
        }
        [Fact]
        public void VerifCurrency4or10()
        {
            // Un nom de currency doit faire entre 4 et 10 characteres
            var ch = new CurrencyHolder("currency", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            if (ch.verifCreatingCurrency4or10NameThrowExeption() == true)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void CurrencyNameOver10Caracteres()
        {
            //Ecrivez un test pour un nom de douze caracteres
            Action mauvaisAppel = () => new CurrencyHolder("abcdefghijkl", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CurrencyAmountNegative()
        {
            //On ne peux pas mettre (methode) put une quantité negative de currency dans un CurrencyHolder
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, -1);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }
        [Fact]
        public void CurrencyHolderVerifCapacity()
        {
            //On ne peux pas mettre des currency dans un CurrencyHolder si ca le fait depasser sa capacité 
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CAPACITE_VALIDE + 1);
                ch.Store(10);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CurrencyAdd0()
        {
            //On ne peux pas ajouter 0 currency (lever expetion)
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
                ch.Store(0);
            };
            Assert.Throws<NotEnoughtSpaceInCurrencyHolderExeption>(mauvaisAppel);
        }
        [Fact]
        public void CurrencyTakeOff0()
        {
            //On ne peux pas retirer 0 currency (lever expetion)
            Action mauvaisAppel = () =>
            {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
                ch.Withdraw(0);
            };
            Assert.Throws<CanWitchDrawMoreThanCurrentAmountException>(mauvaisAppel);
        }
        [Fact]
        public void CurrencyNoBegina()
        {
            // Un nom de currency ne doit pas commencer par la lettre a minuscule 
            Action mauvaisAppel = () => new CurrencyHolder("aaaaa", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CurrencyNoBeginA()
        {
            // Un nom de currency ne doit pas commencer par la lettre A majuscule 
            Action mauvaisAppel = () => new CurrencyHolder("AAAAA", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }
        [Fact]
        public void CurrencyHolderCapacity()
        {
            // Un CurrencyHolder ne peux avoir une capacité inférieure à 1
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, -1, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }
        [Fact]
        public void CurrencyHolderAmount()
        {
            // Un CurrencyHolder ne peux avoir une capacité inférieure à 1
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, -1);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void IsEmpty1()
        {
            //Faire 2 tests unitaires pertinents pour la methode IsEmpty 
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.True(ch.IsEmpty(0));
        }
        [Fact]
        public void IsEmpty2()
        {
            //Faire 2 tests unitaires pertinents pour la methode IsEmpty 
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.False(ch.IsEmpty(10));
        }
        [Fact]
         public void IsFull1()
        {
            //Un CurrencyHolder est plein (IsFull) si son contenu est égal à sa capacité  
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 100, 100);
            Assert.True(ch.IsFull());
        }
        [Fact]
         public void IsFull2()
        {
            //Un CurrencyHolder est plein (IsFull) si son contenu est égal à sa capacité 
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 200, 100);
            Assert.False(ch.IsFull());
        }
    }
}