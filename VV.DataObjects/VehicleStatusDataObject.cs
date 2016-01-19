using System;

namespace VV.DataObjects
{
    public class VehicleStatusDataObject
    {
        public int Id { get; set; }
        public string RONumber { get; set; }
        public DateTime? RODateTime { get; set; }
        public string Tag { get; set; }
        public User CustomerData { get; set; }
        public string Status { get; set; }
        public string LicensePlate { get; set; }
        public VehicleDataObject Vehicle { get; set; }
        public User Advisor { get; set; }
        public DateTime? AppointmentTime { get; set; }
        public DateTime? PromiseTime { get; set; }
        public string Priority { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? ClosedDate { get; set; }
    }
}

/*<parameter_list>
<parameter name="rono">603636</parameter>
<parameter name="roDate">01/18/16</parameter>
<parameter name="rotime"></parameter>
<parameter name="tag">4786</parameter>
<parameter name="CustName">CANADA POST</parameter>
<parameter name="CustNo"/>
<parameter text="See Advisor" color="#CC0000" name="status">Working</parameter>
<parameter name="licno">...552</parameter>
<parameter name="year">2012</parameter>
<parameter name="make"></parameter>
<parameter name="model">TRANSIT CONNECT</parameter>
<parameter name="advname">RICHARD</parameter>
<parameter name="ApptTime"/>
<parameter name="promisetime">17:00</parameter>
<parameter name="promisedate">01/18/16</parameter>
<parameter name="EmailAddress"/>
<parameter name="priority"></parameter>
<parameter name="InvoiceDate"></parameter>
<parameter name="closedDate"/>
</parameter_list>
*/