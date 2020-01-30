using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVehicleFactory
{
    IVehicle Create(VehicleRequirements requirements);
}

//public abstract class AbstractVehicleFactory
//{
//    //public abstract IVehicleFactory CycleFactory();
//    //public abstract IVehicleFactory MotorVehicleFactory();

//    public abstract IVehicle Create();
//}

public class VehicleFactory // : AbstractVehicleFactory
{
    //public override IVehicleFactory CycleFactory()
    //{
    //    return new Cyclefactory();
    //}

    //public override IVehicleFactory MotorVehicleFactory()
    //{
    //    return new MotorVehicleFactory();
    //}

    private readonly IVehicleFactory _factory;
    private readonly VehicleRequirements _requirements;
    
    public VehicleFactory(VehicleRequirements requirements)
    {
        if (requirements.Engine == true && requirements.HasCargo == false) {
            _factory = (IVehicleFactory)new MotorVehicleFactory();
        } else if (requirements.Engine == false && requirements.HasCargo == true) {
            _factory = (IVehicleFactory)new AirplaneVehicleFactory();
        }
        else {
            _factory = new Cyclefactory();
        } 
        _requirements = requirements;
    }

    public IVehicle Create()
    {
        return _factory.Create(_requirements);
    }
}

public class Cyclefactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
            case 1:
                if (requirements.NumberOfWheels == 1){
                    return new Unicycle();
                }
                GameObject.CreatePrimitive(PrimitiveType.Cube);
                return new Bicycle();
            case 2:
                GameObject.CreatePrimitive(PrimitiveType.Cube);
                return new Tandem();
            case 3:
                GameObject.CreatePrimitive(PrimitiveType.Cube);
                return new Tricycle();
            case 4:
                if (requirements.HasCargo)
                {
                    GameObject.CreatePrimitive(PrimitiveType.Cube);
                    return new GoKart();
                }
                GameObject.CreatePrimitive(PrimitiveType.Cube);
                return new FamilyBike();
            default:
                GameObject.CreatePrimitive(PrimitiveType.Cube);
                return new Bicycle();
        }
    }
}

public class MotorVehicleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
           case 2:
                GameObject.CreatePrimitive(PrimitiveType.Cube);
                return new Motorbike();
            default:
                GameObject.CreatePrimitive(PrimitiveType.Cube);
                return new Truck();
        }
    }
}

public class AirplaneVehicleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
            case 2:
                GameObject.CreatePrimitive(PrimitiveType.Cube);
                return new Cessna();
            default:
                GameObject.CreatePrimitive(PrimitiveType.Cube);
                return new Boeing747();
        }
    }
}
