# Object-Relational Structural Patterns

## Table of Contents <!-- omit in toc -->

- [Identity Field](#identity-field)
- [Inheritance Mappers](#inheritance-mappers)
- [Foreign Key Mapping](#foreign-key-mapping)
- [Association Table Mapping](#association-table-mapping)
- [Dependent Mapping](#dependent-mapping)
- [Embedded Value](#embedded-value)
- [Serialized LOB](#serialized-lob)
- [Single Table Inheritance](#single-table-inheritance)
- [Class Table Inheritance](#class-table-inheritance)
- [Concrete Table Inheritance](#concrete-table-inheritance)

### Identity Field

Saves a database ID field in an object to maintain identity between an in-memory object and a database row.

### Inheritance Mappers

A structure to organize database mappers that handle inheritance hierarchies.

### Foreign Key Mapping

Maps an association between objects to a foreign key reference between tables.

### Association Table Mapping

Saves an association as a table with foreign keys to the tables that are linked by the association.

### Dependent Mapping

Has one class perform the database mapping for a child class.

### Embedded Value

Maps an object into several fields of another object's table.

### Serialized LOB

Saves a graph of objects by serializing them into a single large object (LOB), which it stores in a database field.

### Single Table Inheritance

Represents an inheritance hierarchy of classes as a single table that has columns for all the fields of the various classes.

### Class Table Inheritance

Represents an inheritance hierarchy of classes with one table for each class.

### Concrete Table Inheritance

Represents an inheritance hierarchy of classes with one table per concrete class in the hierarchy.
