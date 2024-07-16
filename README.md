# PrimeTechExam

We have a table following fields. like ID, Name, Address. 

The company table uses  several numbers of clients. after a sudden time, separate client needs different fields in the company table as per their business. 

for this, we decided to provide a facility to our clients so that every client add entry fields to the company table. 

Please implement the feature to add customization on the table only for the text/varchar fields.

Please design the database in a way so that in the future another type field can be added.

Task 1: Create CRUD for the company table.
Task 2: Implement company-wise extra field facility.
==================================================================================

# PrimeTech Database Schema

## Overview

This document provides an overview of the database schema used in the PrimeTech application. It describes the tables, their columns, and the relationships between them.

## Tables

### 1. Company

The `Company` table stores information about companies.

| Column     | Type   | Description               |
|------------|--------|---------------------------|
| `Id`       | int    | Primary key               |
| `Name`     | string | Name of the company       |
| `Address`  | string | Address of the company    |

### 2. CustomField

The `CustomField` table stores custom fields added by clients for their specific business needs.

| Column       | Type   | Description                                             |
|--------------|--------|---------------------------------------------------------|
| `Id`         | int    | Primary key                                             |
| `CompanyId`  | int    | Foreign key referencing the `Company` table             |
| `FieldName`  | string | Name of the custom field                                 |
| `FieldValue` | string | Value of the custom field                                |

## Relationships

- **Company to CustomField**: A company can have multiple custom fields associated with it. This is a one-to-many relationship between the `Company` table and the `CustomField` table, where the `CustomField.CompanyId` is a foreign key referencing the `Company.Id`.

## Example Queries

### Select all companies with their custom fields

```sql
SELECT c.Id, c.Name, c.Address, cf.FieldName, cf.FieldValue
FROM Company c
LEFT JOIN CustomField cf ON c.Id = cf.CompanyId;
