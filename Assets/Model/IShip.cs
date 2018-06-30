public interface IShip
{
    float Power { get; }
    float Shield { get; }
    float Steam { get; }
    float Water { get; }
    float Health { get; }
    void AddShield(int value);
    void ReleaseSteam();
    void AddPower(int value);
}