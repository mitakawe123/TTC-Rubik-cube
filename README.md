<h1 align="center">🧩 Rubik's Cube Simulator</h1>

<p align="center">
  A full-stack Rubik’s Cube simulator with a clean API backend and a modern frontend UI.
</p>

<hr/>

## 🚀 Getting Started

### 📦 Prerequisites

#### 🔧 Backend (.NET 9)

- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

#### 🌐 Frontend

- [Node.js](https://nodejs.org/) **v22.14.0**
- [pnpm](https://pnpm.io/)

🧰 Setup Guide
📦 Install pnpm
Make sure pnpm is installed globally:

npm install -g pnpm

<details> <summary>💡 Node version management</summary> Use [nvm](https://github.com/nvm-sh/nvm) or [fnm](https://github.com/Schniz/fnm) to easily manage Node.js versions. </details>

🔙 Backend – ASP.NET Core
🧪 Run Locally
cd RubiksCube.API
dotnet run
📍 The API will be available at:

http://localhost:5272

🎨 Frontend – React + pnpm + vite
💡 Ensure you're using Node.js v22.14.0 and pnpm is installed globally.

📦 Install Dependencies
cd RubiksCubeFE
pnpm install

▶️ Start Development Server
pnpm dev
🌍 The frontend will run at: http://localhost:5173

📁 Project Structure
/RubiksCube.API # ASP.NET Core backend
/RubiksCube.Application # Application layer logic
/RubiksCube.Domain # Domain models and logic
/RubiksCubeFE # Frontend project (React, etc.)
README.md # You're here :)

💡 Notes
The frontend must be configured to call the backend at http://localhost:5272.
CORS should be enabled in the backend to allow requests from the frontend.
