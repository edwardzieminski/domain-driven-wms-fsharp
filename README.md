# Domain Driven WMS (written in F#)

This repo is my exercise trying to implement ideas from Scott Wlaschin's awesome
book [Domain Modeling Made Functional](https://pragprog.com/titles/swdddf/domain-modeling-made-functional/). Instead of
using the domain described in the book, I am using my own example. It is a WMS (Warehouse Management System) designed
for a warehousing services vendor (WRHS Ltd). The warehouse is storing goods owned by a company that distributes
auto detailing chemicals (ADC Inc).

# Domain model description

There are number of business processes in typical warehouse. I will focus on **inbound deliveries**. For bigger picture
(and maybe for later app improvements), I will also list most of usual warehouse business processes:

- Inbound deliveries
- Outbound deliveries
- Internal warehouse movements
- Kitting
- Inventory
- Billing

## Bounded Contexts within Inbound Deliveries process

- Office operations
- Warehouse operations
- Billing operations

## Sticky note colors meaning

![Sticky note colors meaning](readme-images/sticky-note-colors-meaning.png?raw=true)

## Context map

![Context map](readme-images/context-map.png?raw=true)

### Ubiquitous language

| Term                                     | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
|------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **(Inbound) Delivery Notification**      | Message sent from Customer to the Office containing all Inbound Delivery details, including estimated date of delivery and detaild description of delivery contents. Delivery contents is described in lines - each line describes one Inbound Delivery Notification Item.                                                                                                                                                                                                                                                                                                                                      |
| **(Inbound) Delivery Notification Item** | Describes a unit of Inbound Delivery. It is described by following values: [Serial Shipping Container Code (SSCC)](https://www.gs1.org/standards/gs1-logistic-label-guideline/1-3#1-Introduction+1-2-Scope-of-the-guideline) (not available in some deliveries), [EAN-13](https://en.wikipedia.org/wiki/International_Article_Number), Product Code, Batch/LOT (if applicable to the type of product), Serial Numbers (if applicable), Best Before date (if applicable) and quantity                                                                                                                            |
| **Batch/LOT**                            | Optional trait of a product that is being produced in batches. Indicates the batch number. It might be used for example to withdraw the product from the market when some product defect is discovered post-sales. Usually the same batch/LOT number appears on many pieces of a product.                                                                                                                                                                                                                                                                                                                       |
| **Serial number**                        | Similar to batch number, but one serial number is assigned to only one piece of product (for example electronic device).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| **Product types**: Liquids               | Sprays and similar, for example: wheel cleaner, leather cleaner, glass cleaner, dashboard cleaner, liquid wax, car shampoo etc. These products have batch numbers and each batch number has its assigned best before date. Their product codes start with L followed by 6 digits (`L123456`)                                                                                                                                                                                                                                                                                                                    |
| **Product types**: Cleaning equipment    | Examples: microfiber towels, sponges, brushes etc. These products have no batch/lot and no best before date. Their product codes start with E followed with 5 digits (`E12345`)                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| **Product types**: Power tools           | Examples: car polishers, car pressure washers etc. These products have serial numbers. Their product codes start with TL and then 5 digits (`TL12345`)                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| **Product types**: Marketing materials   | Examples: leaflets, catalogues, brochures, marketing stands, branded bags etc. These products have neither batch nor serial numbers, and no best before date. Their product codes start with X, then 5 digits and uppercase letter (A-Z, no diacritics) as the last character (`X12345A`)                                                                                                                                                                                                                                                                                                                       |
| **Product catalog**                      | Customer's API containing up to date product master data, for example EAN13, product code, product description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
| **Tally Sheet**                          | Warehouse internal document that specifies expected delivery contents. It is used by warehouse workers to verify against unloaded physical goods if all expected packages arrived to the warehouse, physical quantity is consistent with expected quantity etc.                                                                                                                                                                                                                                                                                                                                                 |
| **Package label**                        | If the package is not labeled with [GS1 Logistics Label](https://www.gs1.org/standards/gs1-logistic-label-guideline/) (so no SSCC number entered in the Delivery Notification Item), warehouse workers need to label the package with internally printed label, so the package has a barcode that enables quick identification using scanner/RF device connected to the WMS. No matter if product has GS1 Logistics Label or internally printed Package Label - metadata describing the product should be entered to the system, and the key would be the number on the label (also accessible via the barcode) |
| **Discrepancy report**                   | Warehouse document that is shared with the customer. It describes completeness of the unloaded delivery. If there are any shortages - they should be described in the report. Also if any product is damaged - this should also be noted in the report. The report is reflected from Delivery Notification, so it contains the same items, but "enriched" with information about actual quantity and the damage if happened.                                                                                                                                                                                    |
| **Put away**                             | Warehouse process of physical putting delivered goods away to the storage bins. Warehouse worker takes a package, scans the GS1 Logistics Label or Package Label, and target Storage Bin address with scanner/RF device. This operation finalizes Put Away of single delivery item.                                                                                                                                                                                                                                                                                                                             |
| **Storage bin**                          | Also known as (storage) location. Place on an aisle in the warehouse that holds physical goods. Storage bin has an address which consists of aisle number (1st block of the adress, always 2 digits with leading zeroes), stack number (2nd block, 3 digits with leading zeroes) and level number counting from the floor (last block, 1 digit). Sample storage bin address: `12-345-6`. Each aisle stack has labels of all storage bins close to the floor, so warehouse worker can scan it without climbing the aisle when performing put away.                                                               |

### Workflows

![Inbound Delivery notification acknowledgment workflow](readme-images/inbound-delivery-notification-acknowledgment-workflow.png?raw=true)

![Tally Sheet receival workflow](readme-images/tally-sheet-receival-workflow.png?raw=true)

![Delivery unloading workflow](readme-images/delivery-unloading-workflow.png?raw=true)

![Inbound Delivery discrepancy acknowledgment workflow](readme-images/inbound-delivery-discrepancy-acknowledgment-workflow.png?raw=true)

![Inbound Delivery Put Away acknowledgment workflow](readme-images/inbound-delivery-put-away-acknowledgement-workflow.png?raw=true)

![Inbound Delivery invoice issuing workflow](readme-images/inbound-delivery-invoice-issuing-workflow.png?raw=true)