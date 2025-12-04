# 🛰️ Port Scanner

A simple multi-threaded TCP port scanner written in **C#**.  
It performs a full TCP scan over ports **0–65535** for any domain or IP address and prints detected open ports.

---
# ⚠️ Disclaimer
This tool is intended only for legal and educational purposes.
Do not scan a host unless you own it or have explicit permission.
Unauthorized port scanning may violate local laws and acceptable use policies.

## 🚀 Features

- Resolves domain names to IPv4 addresses
- Scans **all ports** asynchronously
- Uses `Task.Run` for parallel execution
- Displays open ports in real time
- Timeout check to avoid blocking connections

---

## 📦 Requirements

- .NET 6.0 or newer
- Windows / Linux / macOS

---

## ▶️ Usage

  ### 1. Build
  
  dotnet build
  
  ### 2. Run
  
  dotnet run
  ### 3. Enter a domain
  
  write the domain (google.com):
  
  ### Sample Output
  
  added port 0
  added port 1
  ...
  open port detected: 80
  open port detected: 443

## 🗂️ Notes
Uses Dns.GetHostEntry() to resolve domain

Uses TcpClient.ConnectAsync with a 300ms timeout

All tasks run asynchronously

