# Base Patterns

## Table of Contents <!-- omit in toc -->

- [Gateway](#gateway)
- [Service Stub](#service-stub)
- [Record Set](#record-set)
- [Mapper](#mapper)
- [Layer Supertype](#layer-supertype)
- [Separated Interface](#separated-interface)
- [Registry](#registry)
- [Value Object](#value-object)
- [Money](#money)
- [Special Case](#special-case)
- [Plugin](#plugin)

## Gateway

An object that encapsulates access to an external system or resource.

## Service Stub

Removes dependence upon problematic services during testing. WSDL

## Record Set

An in-memory representation of tabular data.

## Mapper

An object that sets up a communication between two independent objects.

## Layer Supertype

A type that acts as the supertype for all types in its layer.

## Separated Interface

Defines an interface in a separate package from its implementation.

## Registry

A well-known object that other objects can use to find common objects and services.

## Value Object

A small simple object, like money or a date range, whose equality isn't based on identity.

## Money

Represents a monetary value.

## Special Case

A subclass that provides special behavior for particular cases.

## Plugin

Links classes during configuration rather than compilation.
