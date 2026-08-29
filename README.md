# Task Manager

## Downloads

* **Latest Android Release (.APK):** [Download TasksManager.apk](https://github.com/YarBez12/Task-Manager/releases/download/v1.0/TasksManager.apk)

## Overview

**Task Manager** is a cross-platform mobile application built with **C#**, **.NET MAUI**, and the **MVVM (Model-View-ViewModel)** architecture. Designed to streamline daily workflows and habit tracking, the application enables users to structure high-level tasks alongside detailed sub-exercises, schedule them visually on an interactive calendar, and monitor progress in real time.

The application features full offline persistence via SQLite, dynamic XAML data bindings, asynchronous state updates, and built-in error prevention routines.

---

## Core Features

### 📋 Task & Exercise Lifecycle
* **Task & Sub-Exercise Decomposition:** Create multi-tier tasks with detailed sub-exercises, custom priority levels, and strict deadlines.
* **Granular Completion Tracking:** Toggle progress and execution status for individual exercises or overall task goals.
* **Copy & Paste Buffer:** Built-in custom buffer implementation allowing users to duplicate and re-order exercises across different tasks smoothly.

### 📅 Smart Interactive Schedule
* **Dynamic Daily Schedule View:** Color-coded exercise tracking sorted chronologically for effortless daily planning.
* **Automated Midnight Reset:** Automatic scheduling updates and dynamic date transitions at midnight.
* **Advanced Multi-Criteria Filtering:** Filter and sort tasks by priority, category, completion status, or overdue warnings.

### 📱 Responsive UX & MVVM Architecture
* **XAML Layouts & Styling:** Clean, adaptive UI using resource dictionaries, styles, and value converters.
* **Two-Way Data Binding:** Asynchronous updates between UI controls and ViewModels without code-behind clutter.
* **Input Validation & Error Prevention:** Defensive UI design preventing invalid date entries or overlapping routines.

---

## Technical Stack

* **Framework:** .NET MAUI
* **Language:** C# .NET
* **Architecture:** MVVM Pattern (Model-View-ViewModel)
* **Database & Persistence:** SQLite
* **UI/UX Design:** XAML

---

## Getting Started

### Prerequisites

* **IDE:** Visual Studio 2022 (with *.NET Multi-platform App UI* workload installed)
* **Target Platforms:** Android, iOS, Windows, or macOS

### Installation & Execution

1. **Clone the repository:**
   git clone https://github.com/YarBez12/Task-Manager.git
   cd Task-Manager

2. **Open the Project:**
   Open `TasksManager.sln` in Visual Studio 2022.

3. **Run the App:**
   Select your target emulator or physical device (e.g., Android Emulator) and press **F5**.

---

## Author

**Yaroslav Bezvesilnyi** ([@YarBez12](https://github.com/YarBez12))  
* **Working Email:** yaroslavbezvesilnyi@gmail.com
