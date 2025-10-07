# Object-Relational Behavioral Patterns

## Table of Contents <!-- omit in toc -->

- [Unit of Work](#unit-of-work)
- [Identity Map](#identity-map)
- [Lazy Load](#lazy-load)

## Unit of Work

Maintains a list of objects affected by a business transaction and coordinates the writing out of changes and the resolution of concurrency problems.

## Identity Map

Ensures that each object gets loaded only once by keeping every loaded object in a map. Looks up objects using the map when referring to them.

## Lazy Load

An object that doesn't contain all of the data you need but knows how to get it.

[See more of this pattern ...](./LazyLoad/README.md)
