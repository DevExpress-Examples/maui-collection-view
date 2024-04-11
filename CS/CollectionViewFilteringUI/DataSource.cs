﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CollectionViewFilteringUI.DataSource {
    public class NotificationObject : INotifyPropertyChanged {
        protected bool SetProperty<T>(ref T backingStore, T value, Action onChanged = null, [CallerMemberName] string propertyName = "") {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected bool SetProperty<T>(ref T backingStore, T value, Action<T, T> onChanged, [CallerMemberName] string propertyName = "") {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            T oldValue = backingStore;
            backingStore = value;
            onChanged?.Invoke(oldValue, value);
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
    public class HouseSalesRepository {
        public IList<House> Houses { get; }

        public HouseSalesRepository() {
            Houses = Load();
        }

        static List<House> Load() {
            return new List<House>() {
                new House() { Id = 1, Address = "652 Santa Fe, Riverbank, CA",
                    City = "Riverbank, CA",
                    Price = 780, ImageName = "1",
                    Beds = 4,
                    Baths = 4,
                    HouseSize = 7500,
                    LotSize = 0.8,
                    YearBuilt = 2008,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Buy,
                    Description = "Dishwasher, Disposal, Separate laundry room, 3/4 bath downstairs, Formal dining room, Downstairs family room, Separate family room, Breakfast Bar/Counter, Breakfast nook (eating area), Granite countertops in kitchen, Hardwood flooring in kitchen, Kitchen island, Solid surface countertops in kitchen, Entry foyer, Front living room, Ceiling fan in master bedroom, Master bedroom separate from other, Mirrored door closet in master bedroom, 2nd bedroom: 11x13, 3rd bedroom: 11x14, 4th Bedroom: 18x13, Alarm system owned, Built-in microwave, Carpet, Ceiling fan(s), Convection oven, Double built-in gas ovens, Gas cooktop, Gas stove, Marble/Stone floors" },
                new House() { Id = 2, Address = "82649 Topeka St, Riverbank, CA",
                    City = "Riverbank, CA",
                    Price = 1750, ImageName = "2",
                    Beds = 5,
                    Baths = 3,
                    HouseSize = 12500,
                    LotSize = 1.2,
                    YearBuilt = 2009,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Buy,
                    Description = "Dishwasher, Disposal, Separate laundry room, Full bath downstairs, Formal dining room, Downstairs family room, Separate family room, Breakfast Bar/Counter, Breakfast nook (eating area), Granite countertops in kitchen, Kitchen custom cabinets, Kitchen island, Pantry, Walk-in pantry, Entry foyer, Formal living room, Rear living room, Vaulted ceiling in living room, Balcony in master bedroom, Master bedroom separate from other, Master bedroom upstairs, Sitting room in master bedroom, Walk-in closet in master bedroom, 2nd bedroom: 13X20, 3rd bedroom: 13X17, 4th Bedroom: 13X18, 5th Bedroom: 14X16, Alarm system owned, Blinds, Built-in electric oven, Built-in microwave, Carpet, Ceiling fan(s), Gas cooktop, Intercom system, Marble/Stone floors, Water conditioner owned, Water filtering system, Window Coverings Throughout" },
                new House() { Id = 3, Address = "32822 Donner Trail, Riverbank, CA",
                    City = "Riverbank, CA",
                    Price = 350, ImageName = "3",
                    Beds = 4,
                    Baths = 2,
                    HouseSize = 8356,
                    LotSize = 0.04,
                    YearBuilt = 2010,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Buy,
                    Description = "Dishwasher, Disposal, Refrigerator, Separate laundry room, Washer/Dryer on 2nd floor, Full bath downstairs, Formal dining room, Downstairs family room, Separate family room, Wet bar in family room, Breakfast nook (eating area), Garden window in kitchen, Granite countertops in kitchen, Kitchen island, Marble/Stone flooring in kitchen, Pantry, Formal living room, Front living room, Master bedroom separate from other, Master bedroom upstairs, Sitting room in master bedroom, Walk-in closet in master bedroom, 2nd bedroom: 16x12, 3rd bedroom: 13x16, 4th Bedroom: 18x12, Alarm system owned, Built-in microwave, Carpet, Ceiling fan(s), Double built-in electric ovens, Gas cooktop, Marble/Stone floors" },
                new House() { Id = 4, Address = "5119 Beryl Dr, San Antonio, TX",
                    City = "San Antonio, TX",
                    Price = 455, ImageName = "4",
                    Beds = 4,
                    Baths = 2,
                    HouseSize = 7980,
                    LotSize = 0.7,
                    YearBuilt = 2007,
                    Type = PropertyType.Townhome,
                    Status = PropertyStatus.Rent,
                    Description = "Dishwasher, Disposal, Refrigerator, Separate laundry room, Full bath downstairs, Living/Dining room combo, Separate family room, Breakfast Bar/Counter, Breakfast nook (eating area), Granite countertops in kitchen, Kitchen custom cabinets, Kitchen island, Recessed lighting in kitchen, Tile flooring in kitchen, Walk-in pantry, Formal living room, Front living room, Ceiling fan in master bedroom, Master bedroom downstairs, Walk-in closet in master bedroom, 2nd bedroom: 15x13, 3rd bedroom: 12x12, 4th Bedroom: 14x12, Alarm system owned, Blinds, Built-in microwave, Carpet, Ceiling fan(s), Central vacuum, Convection oven, Double built-in electric ovens, Electric cooktop, Intercom system, Tile floors" },
                new House() { Id = 5, Address = "61207 Monterey St, San Antonio, TX",
                    Price = 1700, ImageName = "5",
                    City = "San Antonio, TX",
                    Beds = 5,
                    Baths = 4,
                    HouseSize = 14250,
                    LotSize = 1.1,
                    YearBuilt = 2010,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Buy,
                    Description = "Dishwasher, Disposal, Separate laundry room, Washer/Dryer on 1st floor, Full bath downstairs, Formal dining room, Downstairs family room, Separate family room, Breakfast Bar/Counter, Breakfast nook (eating area), Granite countertops in kitchen, Kitchen custom cabinets, Kitchen island, Formal living room, Rear living room, Sunken living room, Vaulted ceiling in living room, Balcony in master bedroom, Ceiling fan in master bedroom, Master bedroom separate from other, Master bedroom upstairs, Walk-in closet in master bedroom, 2nd bedroom: 16X17, 3rd bedroom: 14X16, 4th Bedroom: 13X13, 5th Bedroom: 12X12, Blinds, Built-in microwave, Carpet, Ceiling fan(s), Central vacuum, Double built-in electric ovens, Gas cooktop, Marble/Stone floors, Pot shelves, Water conditioner owned, Water filtering system, Window Coverings Throughout" },
                new House() { Id = 6, Address = "8512 Easley St, San Antonio, TX",
                    City = "San Antonio, TX",
                    Price = 250, ImageName = "6",
                    Beds = 3,
                    Baths = 2,
                    HouseSize = 5600,
                    LotSize = 0.2,
                    YearBuilt = 2011,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Buy,
                    Description = "Dishwasher, Disposal, Refrigerator, Separate laundry room, Full bath downstairs, Formal dining room, Built-in bookcases in family room, Downstairs family room, Separate family room, Breakfast Bar/Counter, Breakfast nook (eating area), Granite countertops in kitchen, Kitchen custom cabinets, Kitchen island, Marble/Stone flooring in kitchen, Pantry, Formal living room, Front living room, Ceiling fan in master bedroom, Master bedroom downstairs, Master bedroom separate from other, Sitting room in master bedroom, Walk-in closet in master bedroom, 2nd bedroom: 11X15, 3rd bedroom: 11X14, Alarm system owned, Blinds, Built-in microwave, Carpet, Ceiling fan(s), Double built-in electric ovens, Drapes, Electric cooktop, Marble/Stone floors, Window Coverings Throughout, Wine refrigerator" },
                new House() { Id = 7, Address = "7121 Nevada Ave, Detroit, MI",
                    City = "Detroit, MI",
                    Price = 555, ImageName = "7",
                    Beds = 4,
                    Baths = 3,
                    HouseSize = 6900,
                    LotSize = 2.1,
                    YearBuilt = 2008,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Rent,
                    Description = "Dishwasher, Disposal, Refrigerator, Separate laundry room, Washer/Dryer on 1st floor, Full bath downstairs, Formal dining room, Downstairs family room, Separate family room, Breakfast Bar/Counter, Breakfast nook (eating area), Kitchen island, Recessed lighting in kitchen, Tile countertops in kitchen, Walk-in pantry, Entry foyer, Formal living room, Front living room, Dressing room in master bedroom, Master bedroom separate from other, Master bedroom upstairs, Walk-in closet in master bedroom, 2nd bedroom: 14x16, 3rd bedroom: 12x13, 4th Bedroom: 13x14, Carpet, Double built-in electric ovens, Drywall, Gas cooktop, Manmade wood or laminate floors, Marble/Stone floors, Water conditioner loope" },
                new House() { Id = 8, Address = "620201 Plymouth Rd, Detroit, MI",
                    City = "Detroit, MI",
                    Price = 610, ImageName = "8",
                    Beds = 4,
                    Baths = 4,
                    HouseSize = 7840,
                    LotSize = 0.33,
                    YearBuilt = 2010,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Buy,
                    Description = "Dishwasher, Disposal, Refrigerator, Separate laundry room, Full bath downstairs, Formal dining room, 2+ family rooms, Separate family room, Breakfast nook (eating area), Granite countertops in kitchen, Kitchen custom cabinets, Kitchen island, Walk-in pantry, Entry foyer, Formal living room, Rear living room, Vaulted ceiling in living room, Ceiling fan in master bedroom, Master bedroom downstairs, Walk-in closet in master bedroom, 2nd bedroom: 12x15, 3rd bedroom: 12x15, 4th Bedroom: 12x15, Blinds, Built-in microwave, Carpet, Ceiling fan(s), Electric cooktop, Shutters, Skylight(s), Water conditioner owned, Water filtering system, Window coverings partial" },
                new House() { Id = 9, Address = "1198 Rosslyn Ave, Detroit, MI",
                    City = "Detroit, MI",
                    Price = 320, ImageName = "9",
                    Beds = 4,
                    Baths = 3,
                    HouseSize = 4990,
                    LotSize = 0.8,
                    YearBuilt = 2011,
                    Type = PropertyType.Townhome,
                    Status = PropertyStatus.Buy,
                    Description = "Dishwasher, Disposal, Refrigerator, Separate laundry room, Washer/Dryer on 1st floor, 1/2 bath downstairs, Formal dining room, 2+ family rooms, Built-in bookcases in family room, Breakfast Bar/Counter, Granite countertops in kitchen, Kitchen island, Tile flooring in kitchen, Walk-in pantry, Entry foyer, Formal living room, Built-in bookcases in master bedroom, Built-in entertainment center in master bedroom, Ceiling fan in master bedroom, Dressing room in master bedroom, Walk-in closet in master bedroom, 2nd bedroom: 13x12, 3rd bedroom: 12x12, 4th Bedroom: 13x12, Alarm system rented, Blinds, Built-in microwave, Carpet, Ceiling fan(s), Double built-in gas ovens, Tile floors, Window Coverings Throughout" },
                new House() { Id = 10, Address = "420234 Newport St, Detroit, MI 48234",
                    City = "Detroit, MI",
                    Price = 320, ImageName = "10",
                    Beds = 4,
                    Baths = 3,
                    HouseSize = 6900,
                    LotSize = 3.9,
                    YearBuilt = 2007,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Rent,
                    Description = "Dishwasher, Disposal, Separate laundry room, Full bath downstairs, Formal dining room, Downstairs family room, Separate family room, Granite countertops in kitchen, Kitchen custom cabinets, Vaulted ceiling in living room, Master bedroom downstairs, Master bedroom separate from other, 2nd bedroom: 12x15, 3rd bedroom: 13x13, 4th Bedroom: 12x14, Alarm system owned, Carpet, Ceiling fan(s), Double built-in gas ovens, Marble/Stone floors, Shutters, Window Coverings Throughout" },
                new House() { Id = 11, Address = "6677 Kingsbridge Ln, Jersey City, NJ 07454",
                    City = "Jersey City, NJ",
                    Price = 1100, ImageName = "11",
                    Beds = 5,
                    Baths = 4,
                    HouseSize = 14750,
                    LotSize = 0.99,
                    YearBuilt = 2009,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Buy,
                    Description = "Dishwasher, Disposal, Refrigerator, Separate laundry room, Washer/Dryer on 1st floor, Full bath downstairs, Dining area, Formal dining room, 2+ family rooms, Breakfast Bar/Counter, Kitchen island, Entry foyer, Rear living room, 2 master bedrooms, Balcony in master bedroom, Ceiling fan in master bedroom, Master bedroom downstairs, Master bedroom separate from other, Great room, 2nd bedroom: 15X13, 3rd bedroom: 11X12, 4th Bedroom: 11X12, 5th Bedroom: 11X10, Atrium(s), Blinds, Built-in gas oven, Carpet, Ceiling fan(s), Intercom system, Marble/Stone floors, Pot shelves" },
                new House() { Id = 12, Address = "4815 York St, Jersey City, NJ 78388",
                    City = "Jersey City, NJ",
                    Price = 700, ImageName = "12",
                    Beds = 4,
                    Baths = 3,
                    HouseSize = 9600,
                    LotSize = 1.34,
                    YearBuilt = 2010,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Buy,
                    Description = "Dishwasher, Disposal, Separate laundry room, Washer/Dryer on 1st floor, Full bath downstairs, Formal dining room, Separate family room, Breakfast nook (eating area), Garden window in kitchen, Granite countertops in kitchen, Hardwood flooring in kitchen, Pantry, Entry foyer, Formal living room, Vaulted ceiling in living room, Master bedroom downstairs, Master bedroom separate from other, Walk-in closet in master bedroom, 2nd bedroom: 16X13, 3rd bedroom: 15X14, 4th Bedroom: 17X13, Blinds, Built-in electric oven, Built-in microwave, Carpet, Ceiling fan(s), Central vacuum, Double built-in electric ovens, Electric stove, Intercom system, Shutters, Water conditioner owned" },
                new House() { Id = 13, Address = "115636 Stevens Ave, Jersey City, NJ 35474",
                    City = "Jersey City, NJ",
                    Price = 320, ImageName = "13",
                    Beds = 3,
                    Baths = 3,
                    HouseSize = 45000,
                    LotSize = 1.6,
                    YearBuilt = 2011,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Buy,
                    Description = "Dishwasher, Disposal, Separate laundry room, Washer/Dryer on 1st floor, 1/2 bath downstairs, Formal dining room, Separate family room, Breakfast Bar/Counter, Tile flooring in kitchen, Walk-in pantry, Formal living room, Front living room, Sunken living room, Ceiling fan in master bedroom, Master bedroom separate from other, Master bedroom upstairs, Sitting room in master bedroom, Walk-in closet in master bedroom, 2nd bedroom: 13X14, 3rd bedroom: 12X13, Blinds, Built-in electric oven, Carpet, Ceiling fan(s), Drapes, Drywall, Gas cooktop, Tile floors" },
                new House() { Id = 14, Address = "6351 Gates Ave, Jersey City, NJ 07308",
                    City = "Jersey City, NJ",
                    Price = 320, ImageName = "14",
                    Beds = 4,
                    Baths = 4,
                    HouseSize = 10255,
                    LotSize = 0.3,
                    YearBuilt = 2008,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Rent,
                    Description = "Dishwasher, Disposal, Refrigerator, Separate laundry room, Washer/Dryer on 1st floor, Full bath downstairs, Formal dining room, Downstairs family room, Separate family room, Granite countertops in kitchen, Kitchen custom cabinets, Kitchen island, Tile flooring in kitchen, Rear living room, Master bedroom upstairs, Walk-in closet in master bedroom, 2nd bedroom: 14x14, 3rd bedroom: 11x13, 4th Bedroom: 15x11, Carpet, Double built-in electric ovens, Marble/Stone floors, Tile floors" },
                new House() { Id = 15, Address = "1268 Morton St, Jersey City, NJ 07308",
                    City = "Jersey City, NJ",
                    Price = 320, ImageName = "15",
                    Beds = 4,
                    Baths = 2,
                    HouseSize = 5770,
                    LotSize = 1.3,
                    YearBuilt = 2008,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Rent,
                    Description = "Dishwasher, Disposal, Separate laundry room, Full bath downstairs, Formal dining room, Built-in bookcases in family room, Separate family room, Breakfast Bar/Counter, Breakfast nook (eating area), Garden window in kitchen, Granite countertops in kitchen, Kitchen island, Recessed lighting in kitchen, Tile flooring in kitchen, Entry foyer, Formal living room, Sunken living room, Vaulted ceiling in living room, Ceiling fan in master bedroom, Master bedroom downstairs, Master bedroom separate from other, Walk-in closet in master bedroom, 2nd bedroom: 14x14, 3rd bedroom: 14x14, 4th Bedroom: 14x14, Alarm system owned, Built-in electric oven, Built-in microwave, Carpet, Ceiling fan(s), Central vacuum, Electric cooktop, Intercom system, Marble/Stone floors, Shutters, Tile floors, Water conditioner loope, Window Coverings Throughout" },
                new House() { Id = 16, Address = "32125 4th St NW #2, Washington, DC 20001",
                    City = "Washington, DC",
                    Price = 2800, ImageName = "16",
                    Beds = 5,
                    Baths = 6,
                    HouseSize = 14600,
                    LotSize = 2.3,
                    YearBuilt = 2010,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Rent,
                    Description = "Washer/Dryer on 1st floor, Washer/Dryer on 2nd floor, Full bath downstairs, Breakfast room/Nook, Formal dining room, Downstairs family room, Breakfast Bar/Counter, Breakfast nook (eating area), Granite countertops in kitchen, Kitchen custom cabinets, Kitchen island, Recessed lighting in kitchen, Tile flooring in kitchen, Walk-in pantry, Built-in bookcases in living room, Entry foyer, Formal living room, Vaulted ceiling in living room, Master bedroom upstairs, Sitting room in master bedroom, Walk-in closet in master bedroom, Great room, 2nd bedroom: 20X18, 3rd bedroom: 15X14, 4th Bedroom: 22X19, 5th Bedroom: 14X16, Alarm system owned, Built-in microwave, Carpet, Intercom system, Marble/Stone floors, Shutters, Warming drawer, Water conditioner owned, Window Coverings Throughout, Wine refrigerator" },
                new House() { Id = 17, Address = "7700 Cumberland St, Washington, DC 74021",
                    City = "Washington, DC",
                    Price = 470, ImageName = "17",
                    Beds = 4,
                    Baths = 4,
                    HouseSize = 8530,
                    LotSize = 0.45,
                    YearBuilt = 2009,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Buy,
                    Description = "Dishwasher, Disposal, Separate laundry room, Washer/Dryer on 1st floor, Full bath downstairs, Breakfast room/Nook, Kitchen/Dining room combo, 2+ family rooms, Upstairs &amp; Downstairs family rooms, Wet bar in family room, Breakfast Bar/Counter, Breakfast nook (eating area), Garden window in kitchen, Granite countertops in kitchen, Kitchen custom cabinets, Recessed lighting in kitchen, Tile flooring in kitchen, Walk-in pantry, Entry foyer, Formal living room, Balcony in master bedroom, Ceiling fan in master bedroom, Master bedroom downstairs, Master bedroom separate from other, Walk-in closet in master bedroom, Great room, 2nd bedroom: 14X14, 3rd bedroom: 15X15, 4th Bedroom: 16X14, Alarm system owned, Blinds, Pot shelves, Tile floors, Water conditioner owned, Water filtering system, Window Coverings Throughout, Wine refrigerator" },
                new House() { Id = 18, Address = "8308 Albemarle St NW, Washington, DC 19088",
                    City = "Washington, DC",
                    Price = 1900, ImageName = "18",
                    Beds = 5,
                    Baths = 5,
                    HouseSize = 14100,
                    LotSize = 1.9,
                    YearBuilt = 2009,
                    Type = PropertyType.MultiFamilyHome,
                    Status = PropertyStatus.Buy,
                    Description = "Dishwasher, Disposal, Refrigerator, Separate laundry room, Washer/Dryer on 1st floor, Full bath downstairs, Formal dining room, Built-in bookcases in family room, Separate family room, Breakfast Bar/Counter, Breakfast nook (eating area), Granite countertops in kitchen, Kitchen custom cabinets, Kitchen island, Marble/Stone flooring in kitchen, Recessed lighting in kitchen, Walk-in pantry, Built-in bookcases in living room, Built-in entertainment center, Formal living room, Vaulted ceiling in living room, 2 master bedrooms, Dressing room in master bedroom, Walk-in closet in master bedroom, 2nd bedroom: 17X13, 3rd bedroom: 16X12, 4th Bedroom: 21X21, 5th Bedroom: 12X16, Alarm system owned, Built-in microwave, Carpet, Ceiling fan(s), Central vacuum, Convection oven, Double built-in electric ovens, Gas stove" },
                new House() { Id = 19, Address = "8913 Brandywine St NW, Washington, DC 36863",
                    City = "Washington, DC",
                    Price = 1900, ImageName = "19",
                    Beds = 4,
                    Baths = 3,
                    HouseSize = 12320,
                    LotSize = 0.87,
                    YearBuilt = 2009,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Buy,
                    Description = "Dishwasher, Disposal, Refrigerator, Separate laundry room, Washer/Dryer on 1st floor, Full bath downstairs, Formal dining room, Built-in bookcases in family room, Separate family room, Breakfast Bar/Counter, Breakfast nook (eating area), Granite countertops in kitchen, Kitchen custom cabinets, Kitchen island, Marble/Stone flooring in kitchen, Recessed lighting in kitchen, Walk-in pantry, Built-in bookcases in living room, Built-in entertainment center, Formal living room, Vaulted ceiling in living room, 2 master bedrooms, Dressing room in master bedroom, Walk-in closet in master bedroom, 2nd bedroom: 17X13, 3rd bedroom: 16X12, 4th Bedroom: 21X21, 5th Bedroom: 12X16, Alarm system owned, Built-in microwave, Carpet, Ceiling fan(s), Central vacuum, Convection oven, Double built-in electric ovens, Gas stove" },
                new House() { Id = 20, Address = "13673 Pearl Dr #7, Atascadero, CA 48161",
                    City = "Atascadero, CA",
                    Price = 399, ImageName = "20",
                    Beds = 4,
                    Baths = 2,
                    HouseSize = 7300,
                    LotSize = 0.3,
                    YearBuilt = 2010,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Buy,
                    Description = "Dishwasher, Disposal, Separate laundry room, Full bath downstairs, Formal dining room, Separate family room, Breakfast Bar/Counter, Granite countertops in kitchen, Kitchen custom cabinets, Pantry, Formal living room, Ceiling fan in master bedroom, Master bedroom separate from other, Walk-in closet in master bedroom, 2nd bedroom: 15x15, 3rd bedroom: 13x12, 4th Bedroom: 14x12, Alarm system wired, Built-in microwave, Carpet, Ceiling fan(s), Central vacuum, Double built-in electric ovens, Gas cooktop, Marble/Stone floors, Tile floors, Window coverings partial" },
                new House() { Id = 21, Address = "15447 Traffic Way, Atascadero, CA 93420",
                    City = "Atascadero, CA",
                    Price = 1100, ImageName = "21",
                    Beds = 4,
                    Baths = 3,
                    HouseSize = 11300,
                    LotSize = 1.06,
                    YearBuilt = 2007,
                    Type = PropertyType.MultiFamilyHome,
                    Status = PropertyStatus.Rent,
                    Description = "Dishwasher, Disposal, Refrigerator, Separate laundry room, Washer/Dryer on 2nd floor, 3/4 bath downstairs, Formal dining room, Downstairs family room, Breakfast nook (eating area), Granite countertops in kitchen, Hardwood flooring in kitchen, Kitchen island, Pantry, Formal living room, Front living room, Sunken living room, Vaulted ceiling in living room, Master bedroom separate from other, Master bedroom upstairs, Sitting room in master bedroom, Walk-in closet in master bedroom, 2nd bedroom: 15X11, 3rd bedroom: 12X17, 4th Bedroom: 14X18, Blinds, Built-in microwave, Carpet, Double built-in electric ovens, Drywall, Tile floors, Window Coverings Throughout" },
                new House() { Id = 22, Address = "114840 Interlake Ave N, Seattle, WA 98131",
                    City = "Seattle, WA",
                    Price = 400, ImageName = "22",
                    Beds = 4,
                    Baths = 2,
                    HouseSize = 7990,
                    LotSize = 2.2,
                    YearBuilt = 2007,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Rent,
                    Description = "Dishwasher, Disposal, Refrigerator, Separate laundry room, Full bath downstairs, Formal dining room, Living/Dining room combo, Downstairs family room, Separate family room, Breakfast Bar/Counter, Garden window in kitchen, Kitchen custom cabinets, Tile countertops in kitchen, Tile flooring in kitchen, Walk-in pantry, Entry foyer, Formal living room, Front living room, Vaulted ceiling in living room, Ceiling fan in master bedroom, Master bedroom upstairs, Sitting room in master bedroom, Walk-in closet in master bedroom, 2nd bedroom: 18X15, 3rd bedroom: 18X15, 4th Bedroom: 17X11, Alarm system owned, Built-in microwave, Carpet, Ceiling fan(s), Double built-in gas ovens, Gas cooktop, Intercom system, Shutters, Tile floors, Water conditioner owned, Water filtering system" },
                new House() { Id = 23, Address = "1552 2nd Ave NW, Seattle, WA 98103",
                    City = "Seattle, WA",
                    Price = 330, ImageName = "23",
                    Beds = 4,
                    Baths = 2,
                    HouseSize = 5200,
                    LotSize = 3.66,
                    YearBuilt = 2008,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Rent,
                    Description = "Dishwasher, Disposal, Separate laundry room, Full bath downstairs, Formal dining room, 2+ family rooms, Separate family room, Upstairs &amp; Downstairs family rooms, Breakfast Bar/Counter, Breakfast nook (eating area), Granite countertops in kitchen, Kitchen custom cabinets, Kitchen island, Recessed lighting in kitchen, Tile flooring in kitchen, Entry foyer, Formal living room, Front living room, Vaulted ceiling in living room, Master bedroom separate from other, Walk-in closet in master bedroom, 2nd bedroom: 14X13, 3rd bedroom: 13X13, 4th Bedroom: 14X12, Blinds, Carpet, Ceiling fan(s), Double built-in electric ovens, Gas stove, Pot shelves, Tile floors" },
                new House() { Id = 24, Address = "1552 NE 41st St, Seattle, WA 98105",
                    City = "Seattle, WA",
                    Price = 200, ImageName = "24",
                    Beds = 4,
                    Baths = 3,
                    HouseSize = 6120,
                    LotSize = 1.7,
                    YearBuilt = 2011,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Rent,
                    Description = "Dishwasher, Disposal, Separate laundry room, Washer/Dryer on 1st floor, Full bath downstairs, Dining area, Family/Dining room combo, 2+ family rooms, Downstairs family room, Breakfast Bar/Counter, Granite countertops in kitchen, Kitchen custom cabinets, Recessed lighting in kitchen, Walk-in pantry, Entry foyer, Formal living room, Front living room, Master bedroom upstairs, Walk-in closet in master bedroom, 2nd bedroom: 12x14, 3rd bedroom: 12x13, 4th Bedroom: 13x16, Blinds, Built-in microwave, Carpet, Double built-in gas ovens, Drywall, Gas cooktop, Tile floors, Water conditioner owned, Window Coverings Throughout" },
                new House() { Id = 25, Address = "54732 Bertona St, Seattle, WA 98199",
                    City = "Seattle, WA",
                    Price = 590, ImageName = "25",
                    Beds = 3,
                    Baths = 2,
                    HouseSize = 8300,
                    LotSize = 0.5,
                    YearBuilt = 2009,
                    Type = PropertyType.SingleFamilyHome,
                    Status = PropertyStatus.Buy,
                    Description = "Dishwasher, Disposal, Separate laundry room, Full bath downstairs, Living/Dining room combo, Built-in bookcases in family room, Separate family room, Breakfast Bar/Counter, Garden window in kitchen, Granite countertops in kitchen, Kitchen custom cabinets, Kitchen island, Tile flooring in kitchen, Formal living room, Front living room, Built-in bookcases in master bedroom, Ceiling fan in master bedroom, Master bedroom separate from other, Master bedroom upstairs, Walk-in closet in master bedroom, 2nd bedroom: 12X12, 3rd bedroom: 12X12, Blinds, Built-in microwave, Ceiling fan(s), Double built-in gas ovens, Gas cooktop, Manmade wood or laminate floors, Shutters, Tile floors, Window coverings partial, Window Coverings Throughout" }
            };
        }
    }
    public enum PropertyType {
        [Description("Single Family Home")]
        SingleFamilyHome,
        [Description("Condo/Townhouse")]
        Townhome,
        [Description("Multi-Family Home")]
        MultiFamilyHome
    };
    public enum PropertyStatus {
        [Description("Rent")]
        Rent,
        [Description("Buy")]
        Buy
    };

    public class House : NotificationObject {
        string imageName;

        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Beds { get; set; }
        public int Baths { get; set; }
        public double HouseSize { get; set; }
        public double LotSize { get; set; }
        public decimal Price { get; set; }
        public int YearBuilt { get; set; }
        public bool IsGarageExist => !(Id == 2 || Id == 4 || (Id >= 8 && Id <= 10) || Id == 15 || Id == 17 || Id == 18 || Id == 20 || Id == 22 || Id == 23);
        public PropertyType Type { get; set; }
        public PropertyStatus Status { get; set; }
        public string Description { get; set; }
        public ImageSource ImageSource { get; set; }
        public string ImageName {
            get => this.imageName;
            set {
                this.imageName = value;
                ImageSource = ImageSource.FromFile("house" + value + ".jpg");
            }
        }
        bool isFavorite;
        public bool IsFavorite {
            get => this.isFavorite;
            set => SetProperty(ref this.isFavorite, value);
        }
    }
}
