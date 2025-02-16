
---

# **Finance Tracker System (C#)**

## **Overview**  
The **Finance Tracker System** is a **C# console application** designed to manage financial transactions. It allows users to add, view, and persist transactions. The system uses **file-based storage** for simplicity and demonstrates **basic C# concepts**, including file I/O and object serialization.

## **Features**
- **Add Transaction** – Users can add transactions with an **amount, category, and description**.
- **View Transactions** – Display all stored transactions in a structured format.
- **Data Persistence** – Transactions are stored and retrieved from a **CSV file** (`transactions.csv`).
- **Error Handling** – Ensures smooth operation and graceful handling of file-related errors.


## **Prerequisites**
- .NET SDK **6.0** or higher

## **Installation**
1. Clone the repository:
   ```sh
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```sh
   cd FinanceManagementSystem
   ```
3. Build the project:
   ```sh
   dotnet build
   ```
4. Run the application:
   ```sh
   dotnet run
   ```

---

## **Usage**
### **Adding a Transaction**
1. Enter the amount, category, and description when prompted.
2. The transaction is saved in `transactions.txt`.

### **Viewing Transactions**
- The app will display all stored transactions in a structured format.

## **Example**
Here’s how the **`Program.cs`** file may look:
```csharp
using System;

class Program
{
    static void Main()
    {
        var dataStorage = new DataStorage();
        var financeService = new FinanceService(dataStorage);

        // Adding a transaction
        var transaction = new Transaction(100.00, "Food", "Lunch at cafe");
        financeService.AddTransaction(transaction);

        // Viewing transactions
        financeService.ViewTransactions();
    }
}
```

---

## **License**
This project is licensed under the **MIT License** – see the [LICENSE](LICENSE) file for details.

## **Contact**
For questions or feedback, please contact:
- **Name:** Prajwal Kuchewar
- **Email:** [prajwalkuchewar3@gmail.com](mailto:prajwalkuchewar3@gmail.com)

---

# **Software Requirements Specification (SRS)**  

## **1. Introduction**  

### **1.1 Purpose**  
The **Finance Management System** provides a simple way to manage financial transactions by allowing users to **add, view, and persist** transaction records. It demonstrates **core C# concepts**, including **file I/O and serialization**.

### **1.2 Scope**  
This system will be a **C# console application** with functionalities to:  
- **Add new transactions.**  
- **View all transactions.**  
- **Persist data in a CSV file.**  

### **1.3 Definitions, Acronyms, and Abbreviations**  
- **Transaction** – A financial record containing amount, category, and description.  
- **DataStorage** – A class responsible for file-based transaction persistence.  
- **FinanceService** – A class providing methods to add and view transactions.  

---

## **2. Functional Requirements**  

### **2.1 Add Transaction**  
- **Description:** Users should be able to add a new transaction.  
- **Input:** Amount, category, and description.  
- **Output:** Transaction is stored in `transactions.csv`.  
- **Processing:** Data is serialized and written to the file.  

### **2.2 View Transactions**  
- **Description:** Users should be able to view all stored transactions.  
- **Input:** None.  
- **Output:** Transactions are read from `transactions.csv` and displayed in the console.  

---

## **3. Non-Functional Requirements**  

### **3.1 Performance**  
- The application should efficiently handle a large number of transactions.  

### **3.2 Reliability**  
- The system should handle file errors gracefully.  

### **3.3 Usability**  
- The UI should be simple, intuitive, and provide **clear prompts** for user input.  

### **3.4 Maintainability**  
- The code should be **modular**, with separate classes for transactions, storage, and business logic.  

---

## **4. System Design**  

### **4.1 Architecture**  
- **Model:** `Transaction.cs` (Defines transaction structure).  
- **Storage:** `DataStorage.cs` (Handles file persistence).  
- **Service:** `FinanceService.cs` (Handles transaction logic).  

### **4.2 Data Storage**  
- Transactions are stored in **CSV format** (`transactions.csv`).  
- Example file contents:
  ```
  Amount,Category,Description
  100.00,Food,Lunch at cafe
  250.50,Groceries,Monthly groceries
  ```

### **4.3 User Interface**  
- **Console-based UI** with **clear prompts** for adding and viewing transactions.  

---
