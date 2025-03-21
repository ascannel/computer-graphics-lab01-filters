# Image Processing Application

![C#](https://img.shields.io/badge/C%23-8.0-blue)
![.NET](https://img.shields.io/badge/.NET_Framework-4.7.2-purple)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-Yes-lightgrey)

A Windows Forms application for applying various image filters and transformations. Designed for educational purposes in computer graphics.

## Key Features
- **21 Image Filters**:
  - *Color Manipulation*: Inversion, Grayscale, Sepia, Brightness Up
  - *Spatial Transforms*: Shift (50px right), Autolevels, Perfect Reflector
  - *Matrix Filters*: 
    - Edge Detection (Sobel, Scharr)
    - Blur Effects (Motion Blur, Embossing)
    - Morphological Operations (Dilation, Erosion)
    - Noise Reduction (Median Filter)
  - *Advanced*: Gray World color correction

- **User Interface**:
  - Image preview with zoom
  - Menu-driven filter selection
  - Support for PNG/JPG/BMP formats
  - Instant filter application with status notifications

## Technologies
- **Core**: C# 8.0 + Windows Forms
- **Image Processing**:
  - Direct pixel manipulation (`Bitmap.GetPixel/SetPixel`)
  - Convolution matrices (3x3, 9x9)
  - Morphological kernels (3x3 cross-shaped)
- **Dependencies**: .NET Framework 4.7.2

## Project Structure
```text
.
├── Filters.cs          # All filter implementations (21 classes)
├── Form1.cs            # Main application logic
├── Form1.Designer.cs   # UI layout
└── Program.cs          # Entry point
```
## Usage

1. **Load Image**
`File → Load Image` (Supports PNG/JPG/BMP)

2. **Apply Filters**
Navigate through menu categories:
- *Spot Filters*: Pixel-level transformations
- *Matrix Filters*: Convolution-based operations
3. **Example Workflow**
```text
Load Image → Apply Sobel → Save Result
```
## Filter Implementations
| Category          | Filters                         | Key Algorithms                     |
|-------------------|---------------------------------|------------------------------------|
| Color Adjustment  | Inversion, Sepia, Gray World   | RGB channel manipulation           |
| Spatial Transforms| Shift, Autolevels              | Pixel repositioning/remapping      |
| Edge Detection    | Sobel, Scharr                  | Gradient calculation               |
| Blur Effects      | Motion Blur, Embossing         | Convolution matrices               |
| Morphology        | Dilation, Erosion              | Min/Max operations with 3x3 kernel |
| Noise Reduction   | Median Filter                  | 3x3 neighborhood sorting           |

## Limitations
- No GPU acceleration (CPU-bound processing)
- Limited to small/medium images (performance drops on >4K)
- Basic error handling
- No real-time preview
- Fixed shift offset (50px)

