# AssetTracker

## Overview

**AssetTracker** is a .NET console application designed to manage and track assets in various office locations. The program fetches live currency conversion rates from an online API to accurately convert asset values into the desired currency. This is particularly useful for companies managing assets in multiple currencies and office locations.

## Features

1. **Office Location Management**:
   - Tracks and organizes assets by their assigned office location.
   - Supports input and display of detailed asset information.

2. **Real-Time Currency Conversion**:
   - Retrieves live conversion rates from a specified online service.
   - Converts asset values into different currencies for standardized reporting.

3. **User-Friendly Interaction**:
   - Provides clear and concise output for asset value calculations and currency conversion.

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/PMC/labs-2024.git
   ```
2. Navigate to the project directory:
   ```bash
   cd labs-2024/week49/AssetTracker
   ```
3. Build the project:
   ```bash
   dotnet build
   ```

## Usage

### Running the Program

To execute the program, run the following command:
```bash
dotnet run
```

### Key Functionalities

1. **Fetching Conversion Rates**:
   - The program makes an API call to retrieve current currency conversion rates.
   - Conversion rates are utilized to calculate asset values in the desired target currency.

2. **Displaying Assets**:
   - Displays a list of all tracked assets grouped by office location and expiry date.
   - Shows original and converted values for each asset.

