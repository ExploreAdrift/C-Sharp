Human newHuman = new Human("Doug", 10, 10, 10, 100);
Human humanTarget = new Human("Mark", 7, 3, 9, 150);
Wizard newWizard = new Wizard("Merlin");
Ninja newNinja = new Ninja("Bob");
Samurai newSamurai = new Samurai("Jeff");


newWizard.Attack(humanTarget);
newNinja.Attack(humanTarget);
newNinja.Steal(humanTarget);
newSamurai.Attack(humanTarget);
newSamurai.Meditate();