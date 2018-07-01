public interface IShip
{
    /***
     * Your ship runs on Fuel - no shit! If you want to travel faster you can grab some Fuel and bring it to
     * your tank. Look you for some Fuel floating around in outer space. It might be your only way to get
     * more Fuel.
     */
    float Fuel { get; }

    /***
     * During your travel through space you might encounter some meteriote or other unidentified flying objects.
     * When you get hit, your Shield decreases. When you get hit without any Shield your Ship will get damaged and
     * your Health will decrease.
     */
    float Shield { get; }

    /***
     * Your ship is powered by a steam engine. The Steam pressure will constantly increase by time.
     * The more Steam you have the faster your Ship will travel. But beware! If you gather too much you Steam 
     * Ship will get damaged and you lose Health. Because Steam is evil!
     */
    float Steam { get; }

    /***
     * Health of the Ship. Is this value reaches zero you will die.
     * Don't let this value reach zero, because you will actually die. Like right now!
     */
    float Health { get; }


    void GenerateShield();
    void ReleaseSteam();
    void InsertFuel(float value);
    void Update();
}