namespace VV.DataObjects
{
    public class PriceDataObject
    {
        public int Id { get; set; }
        public long Price { get; set; }
        public bool HidePrice { get; set; }
    }
}

/*
<Price displayName = "Price" > 16200.0000 </ Price >
< HidePrice displayName= "HidePrice" > 0 </ HidePrice >
*/