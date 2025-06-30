# LapShop
**LapShop is an e-commerce system created using the help of the wonderful educational content at [IT Legend](https://itlegend.net/)**

## Key Components

*Customer Facing*
- View items
- Add to cart
- Submit order

*Admin Panel*
- Add item categories
- Add items
- Add Slider content for customer facing pages
- Role-based permission system

## Building
**This project uses .Net 9, Entity Framework Core and Sql Server Management Studio (SSMS) v20.2.30 is needed to use the .bak file**
1. clone the repository
2. restore the database using the bak file in the db folder in SSMS
3. Build the project
**If you'd rather migrate than use the bak file you'll run into a problem where you don't have users with permissions and would have to manually add them to the database, just use the bak file** 

## Areas
- Admin: localhost/admin

## Disclaimer
**This code along with the frontend theme are for educational purposes only, I am not responsible for anyone attempting to utilize this repo for financial gain and or any non-educational purposes**
