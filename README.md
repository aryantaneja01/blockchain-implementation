# Decentralized Blockchain Car Rental System

This project is a functional decentralized blockchain implementation built using C# and the Microsoft .NET Framework. It allows users to engage in car rental bookings while ensuring data integrity through SHA-256 hashing and establishing peer-to-peer networking using WebSockets for full duplex connections.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Usage](#usage)

## Introduction

The Decentralized Blockchain Car Rental System is designed to provide a secure and transparent platform for car rental bookings. It leverages blockchain technology to create a decentralized ledger for recording rental transactions while ensuring the integrity of the data through SHA-256 hashing. Additionally, the system establishes peer-to-peer networking using WebSockets for real-time communication and synchronization of blockchain data across nodes.

## Features

- **Blockchain Technology:** Utilizes a decentralized blockchain to record car rental transactions, making the system tamper-resistant and transparent.

- **Data Integrity:** Ensures data integrity through the use of SHA-256 hashing, making it virtually impossible to alter recorded transactions.

- **Peer-to-Peer Networking:** Establishes peer-to-peer networking using WebSockets, enabling full duplex communication and blockchain synchronization among nodes.

- **Car Rental Bookings:** Provides functionality for users to book cars for rent, record rental transactions on the blockchain, and retrieve rental history.

## Prerequisites

Before you begin, ensure you have the following prerequisites:

- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework) installed on your system.
- C# development environment (e.g., Visual Studio or Visual Studio Code).
- WebSocket library for C# (e.g., [WebSocketSharp](https://github.com/sta/websocket-sharp)).

## Getting Started

To get started with this application, follow these steps:

Clone the repository (if not already done):

```shell
git clone https://github.com/yourusername/blockchain-car-rental.git
cd blockchain-car-rental

Build and run the application using your preferred C# development environment.
Ensure that WebSocket connections are properly configured and accessible for peer-to-peer communication.

Usage

Use the provided API endpoints or user interface to engage in car rental bookings and view transaction history.
Monitor the blockchain to verify the integrity of the recorded rental transactions.
