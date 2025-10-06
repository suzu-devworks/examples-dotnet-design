# Offline Concurrency Patterns

## Table of Contents <!-- omit in toc -->

- [Optimistic Offline Lock](#optimistic-offline-lock)
- [Pessimistic Offline Lock](#pessimistic-offline-lock)
- [Coarse-Grained Lock](#coarse-grained-lock)
- [Implicit Lock](#implicit-lock)

## Optimistic Offline Lock

Prevents conflicts between concurrent business transactions by detecting a conflict and rolling back the transaction.

## Pessimistic Offline Lock

Prevents conflicts between concurrent business transactions by allowing only one business transaction at a time to access data.

## Coarse-Grained Lock

Locks a set of related objects with a single lock.

## Implicit Lock

Allows framework or layer supertype code to acquire offline locks.
