namespace VV.DataObjects
{
    public class ServiceAppointmentDataObject
    {
        /// <summary>
        /// Note this object will require us to change some of the entries that are returned, as they need to conform to the VehicleDataObject
        /// </summary>
        public int Id { get; set; }
        public VehicleDataObject Vehicle { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string AppointmentTime { get; set; }
        public string CustomerNumber { get; set; } //This should eventually tie into the User data object.
        public string NameLast { get; set; } // We should confirm this information...

        public string GetLicenseNumber()
        {
            if (Vehicle != null && !string.IsNullOrEmpty(Vehicle.LicensePlateNumber))
                return string.Format("...{0}", Vehicle.LicensePlateNumber.Substring(3));
            else
                return "";
        }
    }
}

/*<?xml version="1.0"?>
<load date="7/28/2014 12:42:07 AM">
    <Data_Xchange name="Booked1">
        <record>
            <parameter_list>
                <parameter name="Year">2009</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">ML320</parameter>
                <parameter name="Name">Next Available</parameter>
                <parameter name="LicNo">    ...159</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">06:00:00</parameter>
                <parameter name="CustNo">4892195</parameter>
                <parameter name="NameLast">NANTHAKUMAR P.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2009</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">ML320</parameter>
                <parameter name="Name">Andy</parameter>
                <parameter name="LicNo">    ...345</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">07:00:00</parameter>
                <parameter name="CustNo">801890</parameter>
                <parameter name="NameLast">VEERASINGAM S.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2009</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">ML320BT</parameter>
                <parameter name="Name">Daniel</parameter>
                <parameter name="LicNo">    ...171</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">07:00:00</parameter>
                <parameter name="CustNo">4852556</parameter>
                <parameter name="NameLast">DONALD B.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2011</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">E550C</parameter>
                <parameter name="Name">Andy</parameter>
                <parameter name="LicNo">    ...326</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">07:00:00</parameter>
                <parameter name="CustNo">552074</parameter>
                <parameter name="NameLast">ROSELINE T.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">                 </parameter>
                <parameter name="MakePfx">                 </parameter>
                <parameter name="Carline">                 </parameter>
                <parameter name="Name">Next Available</parameter>
                <parameter name="LicNo">                 </parameter>
                <parameter name="EmailAddress">MAJIDZOHARI@YAHOO.COM</parameter>
                <parameter name="ApptTime">07:20:00</parameter>
                <parameter name="CustNo">                 </parameter>
                <parameter name="NameLast">MAJID M.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2013</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">C300W4M</parameter>
                <parameter name="Name">Andy</parameter>
                <parameter name="LicNo">    ...116</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">07:20:00</parameter>
                <parameter name="CustNo">4893487</parameter>
                <parameter name="NameLast">XIAO XI H.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2014</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">C300W4M</parameter>
                <parameter name="Name">Johnny</parameter>
                <parameter name="LicNo">    ...868</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">07:40:00</parameter>
                <parameter name="CustNo">4912067</parameter>
                <parameter name="NameLast">PERCY Y.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2013</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">E350W4M</parameter>
                <parameter name="Name">Daniel</parameter>
                <parameter name="LicNo">    ...ARL</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">07:40:00</parameter>
                <parameter name="CustNo">4858140</parameter>
                <parameter name="NameLast">VYRAMUTHU S.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2005</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">SMART</parameter>
                <parameter name="Name">Jeff</parameter>
                <parameter name="LicNo">    ...691</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">08:00:00</parameter>
                <parameter name="CustNo">4848354</parameter>
                <parameter name="NameLast">ROB M.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2009</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">C230W4M</parameter>
                <parameter name="Name">Andy</parameter>
                <parameter name="LicNo">    ...567</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">08:00:00</parameter>
                <parameter name="CustNo">4845699</parameter>
                <parameter name="NameLast">JAMES L.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">                 </parameter>
                <parameter name="MakePfx">                 </parameter>
                <parameter name="Carline">                 </parameter>
                <parameter name="Name">Johnny</parameter>
                <parameter name="LicNo">                 </parameter>
                <parameter name="EmailAddress">KEITHKKCHAN@GMAIL.COM</parameter>
                <parameter name="ApptTime">08:00:00</parameter>
                <parameter name="CustNo">                 </parameter>
                <parameter name="NameLast">KEITH KA KI C.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2003</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">E500W</parameter>
                <parameter name="Name">Daniel</parameter>
                <parameter name="LicNo">    ...I18</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">08:00:00</parameter>
                <parameter name="CustNo">4875016</parameter>
                <parameter name="NameLast">WAI-CHING I.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2014</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">ML350BT</parameter>
                <parameter name="Name">Andy</parameter>
                <parameter name="LicNo">    ...226</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">08:20:00</parameter>
                <parameter name="CustNo">4912598</parameter>
                <parameter name="NameLast">ZHI WEI Z.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2014</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">ML350</parameter>
                <parameter name="Name">Next Available</parameter>
                <parameter name="LicNo">    ...628</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">08:20:00</parameter>
                <parameter name="CustNo">4909892</parameter>
                <parameter name="NameLast">YUAN Z.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2010</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">E350C</parameter>
                <parameter name="Name">Johnny</parameter>
                <parameter name="LicNo">    ...182</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">08:40:00</parameter>
                <parameter name="CustNo">219356</parameter>
                <parameter name="NameLast">SHUANG X.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2014</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">C300W4M</parameter>
                <parameter name="Name">Andy</parameter>
                <parameter name="LicNo">    ...201</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">08:40:00</parameter>
                <parameter name="CustNo">4840077</parameter>
                <parameter name="NameLast">DUC-MINH V.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2013</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">GLK250BT</parameter>
                <parameter name="Name">Daniel</parameter>
                <parameter name="LicNo">    ...498</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">08:40:00</parameter>
                <parameter name="CustNo">4852233</parameter>
                <parameter name="NameLast">EMILY LAI YI F.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2010</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">E550W4M</parameter>
                <parameter name="Name">Jeff</parameter>
                <parameter name="LicNo">    ...998</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">08:40:00</parameter>
                <parameter name="CustNo">4858424</parameter>
                <parameter name="NameLast">KELVIN C.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2011</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">B200</parameter>
                <parameter name="Name">Johnny</parameter>
                <parameter name="LicNo">    ...608</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">09:00:00</parameter>
                <parameter name="CustNo">4872340</parameter>
                <parameter name="NameLast">CAM-MUOI L.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2012</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">C300W4M</parameter>
                <parameter name="Name">Daniel</parameter>
                <parameter name="LicNo">    ...367</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">09:00:00</parameter>
                <parameter name="CustNo">4886234</parameter>
                <parameter name="NameLast">CHRISTOPHER B F.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2013</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">ML350BT</parameter>
                <parameter name="Name">Next Available</parameter>
                <parameter name="LicNo">    ...973</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">09:00:00</parameter>
                <parameter name="CustNo">4898284</parameter>
                <parameter name="NameLast">LI CHAO C.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2011</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">ML350BT</parameter>
                <parameter name="Name">Daniel</parameter>
                <parameter name="LicNo">    ...967</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">09:20:00</parameter>
                <parameter name="CustNo">4913382</parameter>
                <parameter name="NameLast">NICHOLAS K.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2011</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">C300W4M</parameter>
                <parameter name="Name">Peter</parameter>
                <parameter name="LicNo">    ...800</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">09:20:00</parameter>
                <parameter name="CustNo">4869355</parameter>
                <parameter name="NameLast">WAI-WO L.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2010</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">C350W4M</parameter>
                <parameter name="Name">Johnny</parameter>
                <parameter name="LicNo">    ...680</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">09:20:00</parameter>
                <parameter name="CustNo">4856284</parameter>
                <parameter name="NameLast">MAN SEK TOMSON W.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2014</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">ML350</parameter>
                <parameter name="Name">Andy</parameter>
                <parameter name="LicNo">    ...953</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">09:20:00</parameter>
                <parameter name="CustNo">4911251</parameter>
                <parameter name="NameLast">DAVID Y.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2011</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">C300W4M</parameter>
                <parameter name="Name">Johnny</parameter>
                <parameter name="LicNo">                 </parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">09:40:00</parameter>
                <parameter name="CustNo">4919253</parameter>
                <parameter name="NameLast">YOOI KHEANG N.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2005</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">C230W</parameter>
                <parameter name="Name">Jeff</parameter>
                <parameter name="LicNo">    ...171</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">09:40:00</parameter>
                <parameter name="CustNo">4850588</parameter>
                <parameter name="NameLast">DIONISSIOS B.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2012</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">C250W4M</parameter>
                <parameter name="Name">Peter</parameter>
                <parameter name="LicNo">    ...200</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">09:40:00</parameter>
                <parameter name="CustNo">4875610</parameter>
                <parameter name="NameLast">JUMBO L.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2012</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">C250C</parameter>
                <parameter name="Name">Daniel</parameter>
                <parameter name="LicNo">    ...356</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">09:40:00</parameter>
                <parameter name="CustNo">4852960</parameter>
                <parameter name="NameLast">THUMPER MASSAGER INC</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2010</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">GL350BT</parameter>
                <parameter name="Name">Johnny</parameter>
                <parameter name="LicNo">    ...087</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">10:00:00</parameter>
                <parameter name="CustNo">4855198</parameter>
                <parameter name="NameLast">MUHAMMAD L.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2014</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">CLA250</parameter>
                <parameter name="Name">Daniel</parameter>
                <parameter name="LicNo">    ...403</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">10:00:00</parameter>
                <parameter name="CustNo">4918943</parameter>
                <parameter name="NameLast">ANTHONY B.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">                 </parameter>
                <parameter name="MakePfx">                 </parameter>
                <parameter name="Carline">                 </parameter>
                <parameter name="Name">Andy</parameter>
                <parameter name="LicNo">                 </parameter>
                <parameter name="EmailAddress">BONNIE.WILSON@CHANEL-CORP.COM</parameter>
                <parameter name="ApptTime">10:00:00</parameter>
                <parameter name="CustNo">                 </parameter>
                <parameter name="NameLast">BONNIE W.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2004</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">E320W4M</parameter>
                <parameter name="Name">Peter</parameter>
                <parameter name="LicNo">    ...938</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">10:00:00</parameter>
                <parameter name="CustNo">523052</parameter>
                <parameter name="NameLast">WAI MAN W.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2012</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">R350CDI BLUE TECH</parameter>
                <parameter name="Name">Jeff</parameter>
                <parameter name="LicNo">    ...766</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">10:00:00</parameter>
                <parameter name="CustNo">4911874</parameter>
                <parameter name="NameLast">FRANKIE K.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2012</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">CS5504M</parameter>
                <parameter name="Name">Andy</parameter>
                <parameter name="LicNo">    ...068</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">10:20:00</parameter>
                <parameter name="CustNo">4882164</parameter>
                <parameter name="NameLast">XIAO YU W.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">1994</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">E320W</parameter>
                <parameter name="Name">Jeff</parameter>
                <parameter name="LicNo">    ...VAK</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">10:20:00</parameter>
                <parameter name="CustNo">4832645</parameter>
                <parameter name="NameLast">FAIRGLEN HOMES LIMITED</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2013</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">C300W4M</parameter>
                <parameter name="Name">Daniel</parameter>
                <parameter name="LicNo">    ...340</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">10:20:00</parameter>
                <parameter name="CustNo">4894748</parameter>
                <parameter name="NameLast">ELISA I.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2006</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">B200T</parameter>
                <parameter name="Name">Johnny</parameter>
                <parameter name="LicNo">    ...168</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">10:20:00</parameter>
                <parameter name="CustNo">806427</parameter>
                <parameter name="NameLast">TERESA PUI MAN K.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2009</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">C300W4M</parameter>
                <parameter name="Name">Daniel</parameter>
                <parameter name="LicNo">    ...272</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">10:40:00</parameter>
                <parameter name="CustNo">4842182</parameter>
                <parameter name="NameLast">NGAI MAN W.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2014</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">E350W</parameter>
                <parameter name="Name">Peter</parameter>
                <parameter name="LicNo">    ...058</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">10:40:00</parameter>
                <parameter name="CustNo">4904692</parameter>
                <parameter name="NameLast">LI CINDY X.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2014</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">C300W4M</parameter>
                <parameter name="Name">Johnny</parameter>
                <parameter name="LicNo">    ...196</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">10:40:00</parameter>
                <parameter name="CustNo">4915558</parameter>
                <parameter name="NameLast">YUK-LING C.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2004</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">C240</parameter>
                <parameter name="Name">Andy</parameter>
                <parameter name="LicNo">    ...630</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">11:00:00</parameter>
                <parameter name="CustNo">902091</parameter>
                <parameter name="NameLast">LING W.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">2010</parameter>
                <parameter name="MakePfx">MERCEDES</parameter>
                <parameter name="Carline">E350W4M</parameter>
                <parameter name="Name">Johnny</parameter>
                <parameter name="LicNo">    ...268</parameter>
                <parameter name="EmailAddress">                 </parameter>
                <parameter name="ApptTime">11:00:00</parameter>
                <parameter name="CustNo">4905870</parameter>
                <parameter name="NameLast">BELMONT INTERNATIONAL INC.</parameter>
            </parameter_list>
        </record>
        <record>
            <parameter_list>
                <parameter name="Year">                 </parameter>
                <parameter name="MakePfx">                 </parameter>
                <parameter name="Carline">                 </parameter>
                <parameter name="Name">Next Available</parameter>
                <parameter name="LicNo">                 </parameter>
                <parameter name="EmailAddress">MOU1984@LIVE.COM</parameter>
                <parameter name="ApptTime">11:00:00</parameter>
                <parameter name="CustNo">                 </parameter>
                <parameter name="NameLast">MICHAEL L.</parameter>
            </parameter_list>
        </record>
    </Data_Xchange>
</load>

    */