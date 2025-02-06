# 🚀 Number Classification API  

## 📌 Overview  
The **Number Classification API** is a RESTful service that takes an integer as input and returns its mathematical properties along with a fun fact retrieved from the [Numbers API](http://numbersapi.com).  

---

## ✨ Features  
✔ Determines whether the number is **prime**.  
✔ Checks if the number is **perfect**.  
✔ Identifies whether the number is **Armstrong**.  
✔ Determines if the number is **odd or even**.  
✔ Calculates the **sum of its digits**.  
✔ Fetches a **fun fact** about the number from an external API.  

---

## 🛠 Technology Stack  
- **Framework:** ASP.NET Core Web API  
- **Language:** C#  
- **HTTP Client:** Used to fetch data from the Numbers API  
- **Hosting:** Publicly accessible endpoint  
- **CORS Enabled:** Supports cross-origin requests  

---

## 🌍 API Endpoint  
### **GET /api/classify-number?number={integer}**  

#### 📥 **Request Parameters**  
| Parameter | Type | Description |
|-----------|------|-------------|
| `number`  | `int` | The integer to classify. |

---

## 📤 **Response Examples**  

### ✅ **Success (200 OK)**  
```json
{
    "number": 371,
    "is_prime": false,
    "is_perfect": false,
    "properties": ["armstrong", "odd"],
    "digit_sum": 11,
    "fun_fact": "371 is an Armstrong number because 3^3 + 7^3 + 1^3 = 371"
}
```

### ❌ **Error (400 Bad Request)**  
```json
{
    "error": true,
    "message": "Invalid input. Please provide an integer."
}
```

---

## 🚀 Clone Repository  
```sh
git clone https://github.com/UmukoroHub/number-classification-api
cd number-classification-api

https://hng.tech/hire/csharp-developers