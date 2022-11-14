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

## `Inbound deliveries` related events

![Graph for Inbound deliveries related events](readme-images/inbound-delivery-related-events.png?raw=true)

## `Office Inbound Delivery Handling` context workflows

![Office Inbound Delivery Handling context workflows](readme-images/office-team-inbound-workflows.png?raw=true)

## `Warehouse Inbound Delivery Handling` context workflows

![Warehouse Inbound Delivery Handling context workflows](readme-images/warehouse-team-inbound-workflows.png?raw=true)

## `Billing` context workflows

![Billing context workflows](readme-images/billing-team-inbound-workflows.png?raw=true)
