using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.DataObjects
{
    public class InventoryVehicleDataObject
    {
        public int Id { get; set; }
        public DealerDataObject Dealer { get; set; }

        public string Category { get; set; }
        public string StockNumber { get; set; }
        public string VIN { get; set; }
        public string Status { get; set; }
        public string Year { get; set;}
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public string FuelType { get; set; }
        public string Drive { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public string Doors { get; set; }

        public string Odometer { get; set; }
        public List<string> PhotoLinks { get; set; }

        public PriceDataObject Pricing { get; set; }
        public FinanceDataObject Financing { get; set; }

        public string Options { get; set; }
        public string Description { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        
    }
}
/*

<ADID displayName = "ADID" > 25401933 </ ADID >
< CompanyID displayName="CompanyID">20053146554706</CompanyID>
<CompanyName displayName = "CompanyName" > Edmundston Honda</CompanyName>
<Category displayName = "Category" > Sport Utility</Category>
<StockNumber displayName = "StockNumber" > 11092A</StockNumber>
<Vin displayName = "Vin" > 1FMCU9GXXDUC96891</Vin>
<Status displayName = "Status" > Used </ Status >
< Yrs displayName="Year">2013</Yrs>
<Make displayName = "Make" > Ford </ Make >
< Model displayName="Model">Escape</Model>
<Trim displayName = "Trim" > SE, Heated Seats, Bluetooth, One owner !!</Trim>
<ExtraField displayName = "ExtraField" >
< ContentEN >
< Odometer > 82426 </ Odometer >
< ExteriorColor > Grey </ ExteriorColor >
< InteriorColor > Grey </ InteriorColor >
< FuelType > Gas </ FuelType >
< Drive > 4x4</Drive>
<Engine>I-4 cyl</Engine>
<Transmission>6 Speed Automatic</Transmission>
<Doors>4</Doors>
</ContentEN>
</ExtraField>
<Price displayName = "Price" > 16200.0000 </ Price >
< HidePrice displayName= "HidePrice" > 0 </ HidePrice >
< Options displayName= "Options" >
Air Conditioning, Alloy Wheels, CD Player, Keyless Entry, Power Mirrors, Power Windows, Tilt Steering, Cruise Control, Heated Seats, Power Locks, Bluetooth, Satellite Radio, Tinted Windows, All Wheel Drive
</Options>
<AdDescription displayName = "AdDescription" >
Take command of the road in the 2013 Ford Escape. Smooth gearshifts are achieved thanks to the efficient 4 cylinder engine, and for added security, dynamic Stability Control supplements the drivetrain. Four wheel drive allows you to go places you've only imagined. Ford prioritized fit and finish as evidenced by: delay-off headlights, 1-touch window functionality, a tachometer, adjustable headrests in all seating positions, tilt and telescoping steering wheel, cruise control, and power windows. Audio features include a CD player with MP3 capability, and 6 speakers, enhancing the audio experience throughout the interior. Side curtain airbags deploy in extreme circumstances, shielding you and your passengers from collision forces. You will have a pleasant shopping experience that is fun, informative, and never high pressured. Stop by our dealership or give us a call for more information. Here at Edmundston Honda we take pride in making life as easy as possible for our customers, this is why we offer FREE DELIVERY in the Maritime and Quebec. Prenez les commandes de la route dans le Ford Escape 2013. Changements de vitesse souples sont atteints grâce au moteur 4 cylindres efficace, et pour plus de sécurité, Dynamic Stability Control complète le groupe motopropulseur. Quatre roues motrices vous permet d'aller dans des endroits que vous avez imaginé. Ford priorise ajustement et la finition comme en témoignent: les phares à extinction temporisée, la fonctionnalité de la fenêtre 1-touch, appuie-tête réglables dans toutes les positions assises, inclinable et volant télescopique, régulateur de vitesse, vitres électriques et fonctions audio comprennent un lecteur de CD avec capacité MP3 et 6 haut-parleurs, afin d'améliorer l'expérience audio dans tout l'intérieur. Des rideaux gonflables latéraux se déploient dans des circonstances extrêmes, vous et vos passagers sera protégés des forces de collision. Vous aurez une expérience de magasinage agréable qui est amusant, informatif et ne haute pression. Arrêtez par notre concessionnaire ou appelez-nous pour plus d'informations.Aussi, ici chez Edmundston Honda nous commes fiers de rendre la vie aussi facile que possible pour nos clients, c'est pourquoi nous offrons la livraison gratuite dans les maritimes et le Québec.
</AdDescription>
<FinancingIsAvailable displayName = "FinancingIsAvailable" > 0 </ FinancingIsAvailable >
< FinancingPayment displayName= "FinancingPayment" />
< FinancingPaymentType displayName= "FinancingPaymentType" />
< FinancingNumberOfPayment displayName= "FinancingNumberOfPayment" />
< FinancingDownPayment displayName= "FinancingDownPayment" />
< FinancingSource displayName= "FinancingSource" />
< FinancingType displayName= "FinancingType" />
< FinancingOdometer displayName= "FinancingOdometer" />
< FinancingDescription displayName= "FinancingDescription" />
< ManufactureProgram displayName= "ManufactureProgram" />
< Warranty displayName= "Warranty" > Not Available</Warranty>
<WarrantyDescription displayName = "WarrantyDescription" />
< MainPhoto displayName= "MainPhoto" >
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/7461f607-3b42-4570-a34b-ac3b82a814c0.jpg?w=420&h=315
</MainPhoto>
<AditionalPhotos displayName = "AditionalPhotos" >
< AditionalPhoto >
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/b45bd3d1-a1cf-45c2-8fb9-4869ec3558a3.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/e031fbb5-bac9-4117-9431-bcf3f11d2db6.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/43b21964-6c16-4e9b-a170-5889a575b571.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/f4b817c4-098a-472e-af51-21d7f86b02db.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/90f26cd6-9fb4-4c6f-9672-399a29d9fc5a.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/e85b6bfb-609e-4b2a-9b9d-6fd74000c686.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/dd05f8e2-672d-4d0b-9969-6fcb74046c79.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/f983b19c-241d-4a2b-9f53-b76a055f7c5f.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/d3546f9c-f696-4f10-a6cd-107b79765a4b.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/4be365b3-faf1-4d10-8696-8d099a13bd4c.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/368daa86-c0a4-40cc-a559-2e8931a363c3.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/abdf6ee7-2688-4196-85ec-4d943253c75b.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/147f64f6-3fab-4ac3-8a7b-866db0a4c54f.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/d1e58626-40db-4f15-856a-88070e951cca.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/48e63e48-f8fd-4374-8b93-48487c9d09ab.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/e5334eb2-945d-429b-b1ec-69d76d20ff4a.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/ccfe50a7-0c36-429b-bf81-e74eae599716.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/dd153f64-893e-45f1-abed-933a7fde167f.jpg?w=420&h=315
</AditionalPhoto>
<AditionalPhoto>
http://azr.cdnmedia.autotrader.ca/5/photos/import/201601/1215/2118/9f1a738f-6439-477b-8e8f-cb9dd12b5392.jpg?w=420&h=315
</AditionalPhoto>
</AditionalPhotos>
<ModifiedDate displayName = "ModifiedDate" > 01 / 12 / 2016 15:23:00</ModifiedDate>
<CreatedDate displayName = "CreatedDate" > 09 / 18 / 2015 19:44:52</CreatedDate>
</AD>

                           */