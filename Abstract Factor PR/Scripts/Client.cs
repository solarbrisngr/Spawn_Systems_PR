using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviour
{
    public int NumberOfWheels;
    public bool Engine;
    public int Passengers;
    public bool Cargo;

    public Slider sliderWheels;
    public Slider sliderPassengers;

    public Toggle engine;
    public Toggle cargo;

    // Start is called before the first frame update
    void Start()
    {
        VehicleRequirements requirements = new VehicleRequirements();

        requirements.NumberOfWheels = (int)sliderWheels.value;
        requirements.Engine = engine;
        requirements.Passengers = (int)sliderPassengers.value;
        requirements.HasCargo = cargo;

        //IVehicle v = GetVehicle(requirements);
        VehicleFactory factory = new VehicleFactory(requirements);
        IVehicle v = factory.Create();
        Debug.Log(v);
    }

    // Update is called once per frame
    void Update()
    {
        VehicleRequirements requirements = new VehicleRequirements();

        requirements.NumberOfWheels = (int)sliderWheels.value;
        requirements.Engine = engine;
        requirements.Passengers = (int)sliderPassengers.value;
        requirements.HasCargo = cargo;

        //IVehicle v = GetVehicle(requirements);
        VehicleFactory factory = new VehicleFactory(requirements);
        IVehicle v = factory.Create();
        Debug.Log(v);
    }

    //private static IVehicle GetVehicle(VehicleRequirements requirements)
    //{
    //    VehicleFactory factory = new VehicleFactory();
    //    //IVehicle vehicle;

    //    if (requirements.Engine)
    //    {
    //        return factory.MotorVehicleFactory().Create(requirements);
    //    }

    //    return factory.CycleFactory().Create(requirements);
    //}
}
