# Domain Driven WMS (written in F#)

This repo is my exercise trying to implement ideas from Scott Wlaschin's awesome
book [Domain Modeling Made Functional](https://pragprog.com/titles/swdddf/domain-modeling-made-functional/). Instead of
using the domain described in the book, I am using my own example. It is a WMS (Warehouse Management System) designed
for a warehousing services vendor (WRHS Ltd). The warehouse is storing goods owned by a company that distributes
cosmetics (Acme Inc).

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

### Workflows

![Inbound Delivery notification acknowledgment workflow](readme-images/inbound-delivery-notification-acknowledgment-workflow.png?raw=true)

![Tally Sheet receival workflow](readme-images/tally-sheet-receival-workflow.png?raw=true)

![Delivery unloading workflow](readme-images/delivery-unloading-workflow.png?raw=true)

![Inbound Delivery discrepancy acknowledgment workflow](readme-images/inbound-delivery-discrepancy-acknowledgment-workflow.png?raw=true)

![Inbound Delivery Put Away acknowledgment workflow](readme-images/inbound-delivery-put-away-acknowledgement-workflow.png?raw=true)

![Inbound Delivery invoice issuing workflow](readme-images/inbound-delivery-invoice-issuing-workflow.png?raw=true)