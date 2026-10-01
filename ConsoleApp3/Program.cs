namespace ConsoleApp3   
{
    public class Program
    {
        static void Main(string[] args)
        {
            //abstracton is way that we hide details of system implementation and  show the functionality to user and reduse complixity and difficality for user,let it use program without need to know how it works
            //abstraction is  one of  pillars of object oriented programming it let system to be more flexible and reusable and easy to maintain and understand
            //the deference between abstraction and interface is that abstraction can run on class and accessable with explicit modefier and support fields all of this is inverse with interface


            StrandardShipment standard = new StrandardShipment
            {
                TrackingCode = "SH001",
                Weight = 2.5m,
                DeliveryDate = "2026-10-05",
                Address = "Cairo, Egypt"
            };

            ExpressShipment express = new ExpressShipment
            {
                TrackingCode = "SH002",
                Weight = 1.0m,
                DeliveryDate = "2026-10-02",
                Address = "Alexandria, Egypt"
            };

            InternationalShipment international = new InternationalShipment
            {
                TrackingCode = "SH003",
                Weight = 5.0m,
                DeliveryDate = "2026-10-10",
                Address = "Dubai, UAE"
            };

             
            DeliveryCenter center = new DeliveryCenter();
            center.Shipments.Add(standard);
            
            // center.Shipments.Add(express);
            // center.Shipments.Add(international);

           
            Console.WriteLine("=== 1. Print Shipment Details ===");
            standard.printShipment();
            express.printShipment();
            international.printShipment();

          
            Console.WriteLine("\n=== 2. Tracking Statuses via DeliveryCenter ===");
            center.PrintTrackingStatuses();

            
            Console.WriteLine("\n=== 3. ITrackable Array ===");
            ITrackable[] trackableItems = new ITrackable[] { standard };
            foreach (ITrackable item in trackableItems)
            {
                Console.WriteLine(item.GetTrackingStatus());
            }

           
            Console.WriteLine("\n=== 4. IInsurable Array ===");
            // IInsurable[] insurableItems = new IInsurable[] { standard, express, international };
            // foreach (IInsurable item in insurableItems)
            // {
            //     Console.WriteLine("Insurance: " + item.CalculateInsurance());
            // }









        }
        public abstract class Shipment
        {
            
            public string TrackingCode { get; set; }
        
            public decimal Weight { get; set; }
            public string DeliveryDate { get; set; }
            public string Address { get; set; }
            public abstract decimal EstimatedCost { get; set; }

            public abstract void printShipment();

        }
        public class AirShipment : Shipment
        {
            public override decimal EstimatedCost { get; set; }
            public override void printShipment()
            {
                Console.WriteLine($"Air Shipment - Tracking Code: {TrackingCode}, Weight: {Weight}, Delivery Date: {DeliveryDate}, Address: {Address}, Estimated Cost: {EstimatedCost}");
            }
        }

        public class ExpressShipment : Shipment
        {
            public override decimal EstimatedCost { get; set; }
            public override void printShipment()
            {

                Console.WriteLine($"Express Shipment - Tracking Code: {TrackingCode}, Weight: {Weight}, Delivery Date: {DeliveryDate}, Address: {Address}, Estimated Cost: {EstimatedCost}");
            }
        }
        public class InternationalShipment : Shipment
        {
            public override decimal EstimatedCost { get; set; }
            public override void printShipment()
            {
                Console.WriteLine($"International Shipment - Tracking Code: {TrackingCode}, Weight: {Weight}, Delivery Date: {DeliveryDate}, Address: {Address}, Estimated Cost: {EstimatedCost}");
            }
        }

        public interface ITrackable
        { 
        
        string GetTrackingthing();




        }

        public class StrandardShipment : Shipment, ITrackable
        {
            public override decimal EstimatedCost { get; set; }
            public override void printShipment()
            {
                Console.WriteLine($"Standard Shipment - Tracking Code: {TrackingCode}, Weight: {Weight}, Delivery Date: {DeliveryDate}, Address: {Address}, Estimated Cost: {EstimatedCost}");
            }
            public string GetTrackingthing()
            {
                return $"Standard Shipment - Tracking Code: {TrackingCode}";
            }
        }
        public interface IInsurable
        {
            decimal CalculateInsurance();
        }
        public class DeliveryReport
        {
            public void PrintShipment(ITrackable shipment)
            {
                Console.WriteLine(shipment.GetTrackingStatus());
            }

            
            public void PrintInsurance(IInsurable shipment)
            {
                Console.WriteLine("Insurance Cost: " + shipment.CalculateInsurance());
            }
        }

        public class DeliveryCenter
        {
            
            public List<ITrackable> Shipments { get; set; } = new List<ITrackable>();

            public void PrintTrackingStatuses()
            {
                
                foreach (ITrackable t in Shipments)
                {
                    Console.WriteLine(t.GetTrackingStatus());
                }
            }
        }


    }












}
