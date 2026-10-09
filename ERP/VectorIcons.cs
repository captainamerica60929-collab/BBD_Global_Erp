using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CRM_App
{
    /// <summary>
    /// High-precision anti-aliased GDI+ vector graphics renderer.
    /// Provides pixel-perfect, resolution-independent vector icons matching the reference image.
    /// </summary>
    public static class VectorIcons
    {
        /// <summary>
        /// Draws the large green circular user avatar icon for the login header.
        /// </summary>
        public static void DrawUserCircle(Graphics g, Rectangle bounds, Color circleColor, Color iconColor)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Green circle background
            using (SolidBrush brush = new SolidBrush(circleColor))
            {
                g.FillEllipse(brush, bounds);
            }

            int cx = bounds.X + bounds.Width / 2;
            int cy = bounds.Y + bounds.Height / 2;
            int r = bounds.Width / 2;

            using (SolidBrush iconBrush = new SolidBrush(iconColor))
            {
                // Head circle
                int headR = (int)(r * 0.36f);
                int headY = cy - (int)(r * 0.44f);
                g.FillEllipse(iconBrush, cx - headR, headY, headR * 2, headR * 2);

                // Shoulders (clipped to circle)
                GraphicsState state = g.Save();
                using (GraphicsPath clipPath = new GraphicsPath())
                {
                    clipPath.AddEllipse(bounds);
                    g.SetClip(clipPath);

                    int bodyW = (int)(r * 1.55f);
                    int bodyH = (int)(r * 1.25f);
                    int bodyY = cy + (int)(r * 0.12f);

                    using (GraphicsPath bodyPath = new GraphicsPath())
                    {
                        bodyPath.AddEllipse(cx - bodyW / 2, bodyY, bodyW, bodyH);
                        g.FillPath(iconBrush, bodyPath);
                    }
                }
                g.Restore(state);
            }
        }

        /// <summary>
        /// Draws the user silhouette outline icon for username labels and footer.
        /// </summary>
        public static void DrawUserOutline(Graphics g, Rectangle bounds, Color color, float penWidth = 1.8f)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(color, penWidth))
            {
                pen.LineJoin = LineJoin.Round;
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                int cx = bounds.X + bounds.Width / 2;
                int headRadius = bounds.Width / 4;
                int headY = bounds.Y + 2;

                // Head
                g.DrawEllipse(pen, cx - headRadius, headY, headRadius * 2, headRadius * 2);

                // Body arc
                int bodyY = headY + headRadius * 2 + 3;
                int bodyW = bounds.Width - 4;
                int bodyH = bounds.Height - (bodyY - bounds.Y) + 2;

                g.DrawArc(pen, bounds.X + 2, bodyY, bodyW, bodyH * 2, 195, 150);
            }
        }

        /// <summary>
        /// Draws the lock outline icon for password labels.
        /// </summary>
        public static void DrawLockOutline(Graphics g, Rectangle bounds, Color color, float penWidth = 1.8f)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(color, penWidth))
            {
                pen.LineJoin = LineJoin.Round;
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                int cx = bounds.X + bounds.Width / 2;
                int bodyW = (int)(bounds.Width * 0.78f);
                int bodyH = (int)(bounds.Height * 0.54f);
                int bodyX = cx - bodyW / 2;
                int bodyY = bounds.Bottom - bodyH - 1;

                // Body
                using (GraphicsPath path = CreateRoundedRectPath(new Rectangle(bodyX, bodyY, bodyW, bodyH), 3))
                {
                    g.DrawPath(pen, path);
                }

                // Shackle
                int shackleW = (int)(bodyW * 0.60f);
                int shackleX = cx - shackleW / 2;
                int shackleY = bounds.Y + 2;
                int shackleH = (bodyY - shackleY) * 2;

                g.DrawArc(pen, shackleX, shackleY, shackleW, shackleH, 180, 180);

                // Keyhole
                using (SolidBrush b = new SolidBrush(color))
                {
                    int keyholeR = 2;
                    g.FillEllipse(b, cx - keyholeR, bodyY + (int)(bodyH * 0.32f), keyholeR * 2, keyholeR * 2);
                    g.DrawLine(pen, cx, bodyY + (int)(bodyH * 0.32f) + keyholeR, cx, bodyY + (int)(bodyH * 0.68f));
                }
            }
        }

        /// <summary>
        /// Draws the password eye visibility toggle icon.
        /// </summary>
        public static void DrawEyeIcon(Graphics g, Rectangle bounds, Color color, bool strikeThrough, float penWidth = 1.6f)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(color, penWidth))
            {
                pen.LineJoin = LineJoin.Round;
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                int cx = bounds.X + bounds.Width / 2;
                int cy = bounds.Y + bounds.Height / 2;
                int w = bounds.Width - 4;
                int h = 10;

                // Upper & lower eye curves
                using (GraphicsPath eyePath = new GraphicsPath())
                {
                    eyePath.AddArc(bounds.X + 2, cy - h, w, h * 2, 28, 124);
                    g.DrawPath(pen, eyePath);
                }
                using (GraphicsPath eyePath2 = new GraphicsPath())
                {
                    eyePath2.AddArc(bounds.X + 2, cy - h, w, h * 2, 208, 124);
                    g.DrawPath(pen, eyePath2);
                }

                // Center pupil
                int pupilR = 2;
                using (SolidBrush b = new SolidBrush(color))
                {
                    g.FillEllipse(b, cx - pupilR, cy - pupilR, pupilR * 2, pupilR * 2);
                }

                // Diagonal slash when password is masked
                if (strikeThrough)
                {
                    g.DrawLine(pen, bounds.X + 3, bounds.Y + 2, bounds.Right - 3, bounds.Bottom - 2);
                }
            }
        }

        /// <summary>
        /// Draws the login door and entrance arrow icon for the Sign In button.
        /// </summary>
        public static void DrawLoginArrow(Graphics g, Rectangle bounds, Color color, float penWidth = 2.0f)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(color, penWidth))
            {
                pen.LineJoin = LineJoin.Round;
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                int w = bounds.Width;
                int h = bounds.Height;
                int x = bounds.X;
                int y = bounds.Y;

                // Door frame [
                int frameW = (int)(w * 0.44f);
                int frameH = (int)(h * 0.85f);
                int frameY = y + (h - frameH) / 2;
                int frameX = x + (int)(w * 0.12f);

                Point[] bracket = new Point[]
                {
                    new Point(frameX + frameW, frameY),
                    new Point(frameX, frameY),
                    new Point(frameX, frameY + frameH),
                    new Point(frameX + frameW, frameY + frameH)
                };
                g.DrawLines(pen, bracket);

                // Right arrow entering door
                int arrowY = y + h / 2;
                int arrowStartX = frameX + (int)(frameW * 0.15f);
                int arrowEndX = x + w - 2;

                g.DrawLine(pen, arrowStartX, arrowY, arrowEndX, arrowY);

                // Arrow head
                int headSize = (int)(h * 0.26f);
                g.DrawLine(pen, arrowEndX - headSize, arrowY - headSize, arrowEndX, arrowY);
                g.DrawLine(pen, arrowEndX - headSize, arrowY + headSize, arrowEndX, arrowY);
            }
        }

        /// <summary>
        /// Draws the database / server stacked disks icon for the footer.
        /// </summary>
        public static void DrawDatabaseIcon(Graphics g, Rectangle bounds, Color color, float penWidth = 1.7f)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(color, penWidth))
            {
                pen.LineJoin = LineJoin.Round;
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                int x = bounds.X + 2;
                int w = bounds.Width - 4;
                int diskH = 7;
                int y1 = bounds.Y + 2;
                int y2 = y1 + 5;
                int y3 = y2 + 5;

                // Top disk ellipse
                g.DrawEllipse(pen, x, y1, w, diskH);

                // Vertical sides
                g.DrawLine(pen, x, y1 + diskH / 2, x, y3 + diskH / 2);
                g.DrawLine(pen, x + w, y1 + diskH / 2, x + w, y3 + diskH / 2);

                // Lower arcs
                g.DrawArc(pen, x, y2, w, diskH, 0, 180);
                g.DrawArc(pen, x, y3, w, diskH, 0, 180);
            }
        }

        /// <summary>
        /// Draws the calendar icon for AMC in the footer.
        /// </summary>
        public static void DrawCalendarIcon(Graphics g, Rectangle bounds, Color color, float penWidth = 1.7f)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(color, penWidth))
            {
                pen.LineJoin = LineJoin.Round;
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                int x = bounds.X + 2;
                int y = bounds.Y + 3;
                int w = bounds.Width - 4;
                int h = bounds.Height - 5;

                // Body
                using (GraphicsPath path = CreateRoundedRectPath(new Rectangle(x, y, w, h), 3))
                {
                    g.DrawPath(pen, path);
                }

                // Header line
                int headerY = y + (int)(h * 0.32f);
                g.DrawLine(pen, x, headerY, x + w, headerY);

                // Binder tabs
                int ring1X = x + (int)(w * 0.28f);
                int ring2X = x + (int)(w * 0.72f);
                g.DrawLine(pen, ring1X, y - 2, ring1X, y + 2);
                g.DrawLine(pen, ring2X, y - 2, ring2X, y + 2);

                // Grid dots
                using (SolidBrush brush = new SolidBrush(color))
                {
                    int dotSize = 2;
                    int row1Y = headerY + 4;
                    int row2Y = row1Y + 4;

                    g.FillRectangle(brush, x + (int)(w * 0.25f), row1Y, dotSize, dotSize);
                    g.FillRectangle(brush, x + (int)(w * 0.50f), row1Y, dotSize, dotSize);
                    g.FillRectangle(brush, x + (int)(w * 0.75f), row1Y, dotSize, dotSize);

                    g.FillRectangle(brush, x + (int)(w * 0.25f), row2Y, dotSize, dotSize);
                    g.FillRectangle(brush, x + (int)(w * 0.50f), row2Y, dotSize, dotSize);
                    g.FillRectangle(brush, x + (int)(w * 0.75f), row2Y, dotSize, dotSize);
                }
            }
        }

        /// <summary>
        /// Draws a 3-line hamburger menu icon.
        /// </summary>
        public static void DrawHamburgerIcon(Graphics g, Rectangle bounds, Color color, float penWidth = 2.0f)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(color, penWidth))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                int padX = bounds.Width / 5;
                int x1 = bounds.X + padX;
                int x2 = bounds.Right - padX;
                int cy = bounds.Y + bounds.Height / 2;
                int gap = bounds.Height / 4;
                g.DrawLine(pen, x1, cy - gap, x2, cy - gap);
                g.DrawLine(pen, x1, cy, x2, cy);
                g.DrawLine(pen, x1, cy + gap, x2, cy + gap);
            }
        }

        /// <summary>
        /// Draws a Home / House icon.
        /// </summary>
        public static void DrawHomeIcon(Graphics g, Rectangle bounds, Color color, float penWidth = 1.8f)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(color, penWidth))
            {
                pen.LineJoin = LineJoin.Round;
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                int cx = bounds.X + bounds.Width / 2;
                int topY = bounds.Y + 3;
                int bottomY = bounds.Bottom - 3;
                int w = (int)(bounds.Width * 0.70f);
                int h = bottomY - topY;
                int roofBottomY = topY + (int)(h * 0.45f);

                // Roof peak
                g.DrawLines(pen, new Point[] {
                    new Point(cx - w / 2, roofBottomY),
                    new Point(cx, topY),
                    new Point(cx + w / 2, roofBottomY)
                });

                // House body
                int bodyW = (int)(w * 0.72f);
                int bodyX = cx - bodyW / 2;
                g.DrawLines(pen, new Point[] {
                    new Point(bodyX, roofBottomY),
                    new Point(bodyX, bottomY),
                    new Point(bodyX + bodyW, bottomY),
                    new Point(bodyX + bodyW, roofBottomY)
                });

                // Door
                int doorW = (int)(bodyW * 0.38f);
                int doorH = (int)((bottomY - roofBottomY) * 0.55f);
                g.DrawRectangle(pen, cx - doorW / 2, bottomY - doorH, doorW, doorH);
            }
        }

        /// <summary>
        /// Draws a Shopping Cart icon for Purchase / Orders.
        /// </summary>
        public static void DrawCartIcon(Graphics g, Rectangle bounds, Color color, float penWidth = 1.8f)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(color, penWidth))
            using (SolidBrush brush = new SolidBrush(color))
            {
                pen.LineJoin = LineJoin.Round;
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                int x = bounds.X + 2;
                int y = bounds.Y + 3;
                int w = bounds.Width - 4;
                int h = bounds.Height - 6;

                // Handle & basket
                Point[] cart = new Point[] {
                    new Point(x, y + 2),
                    new Point(x + (int)(w * 0.18f), y + 2),
                    new Point(x + (int)(w * 0.32f), y + (int)(h * 0.70f)),
                    new Point(x + (int)(w * 0.88f), y + (int)(h * 0.70f)),
                    new Point(x + w, y + (int)(h * 0.20f)),
                    new Point(x + (int)(w * 0.25f), y + (int)(h * 0.20f))
                };
                g.DrawLines(pen, cart);

                // Wheels
                int wheelR = 2;
                int wheelY = y + (int)(h * 0.85f);
                g.FillEllipse(brush, x + (int)(w * 0.38f) - wheelR, wheelY, wheelR * 2, wheelR * 2);
                g.FillEllipse(brush, x + (int)(w * 0.78f) - wheelR, wheelY, wheelR * 2, wheelR * 2);
            }
        }

        /// <summary>
        /// Draws a Clipboard / Checkmark icon for Approvals / Quality.
        /// </summary>
        public static void DrawClipboardCheckIcon(Graphics g, Rectangle bounds, Color color, float penWidth = 1.8f)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(color, penWidth))
            {
                pen.LineJoin = LineJoin.Round;
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                int x = bounds.X + 3;
                int y = bounds.Y + 4;
                int w = bounds.Width - 6;
                int h = bounds.Height - 7;

                // Board
                using (GraphicsPath path = CreateRoundedRectPath(new Rectangle(x, y, w, h), 3))
                {
                    g.DrawPath(pen, path);
                }

                // Clip top
                int clipW = (int)(w * 0.44f);
                int clipH = 4;
                int clipX = bounds.X + (bounds.Width - clipW) / 2;
                using (GraphicsPath clip = CreateRoundedRectPath(new Rectangle(clipX, y - 2, clipW, clipH), 2))
                {
                    g.DrawPath(pen, clip);
                }

                // Checkmark
                int cx = bounds.X + bounds.Width / 2;
                int cy = bounds.Y + bounds.Height / 2 + 1;
                g.DrawLines(pen, new Point[] {
                    new Point(cx - 4, cy),
                    new Point(cx - 1, cy + 3),
                    new Point(cx + 5, cy - 3)
                });
            }
        }

        /// <summary>
        /// Draws an Excel Sheet icon.
        /// </summary>
        public static void DrawExcelIcon(Graphics g, Rectangle bounds, Color color)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int x = bounds.X + 2;
            int y = bounds.Y + 2;
            int w = bounds.Width - 4;
            int h = bounds.Height - 4;

            // Sheet outline
            using (Pen pen = new Pen(color, 1.5f))
            {
                using (GraphicsPath path = CreateRoundedRectPath(new Rectangle(x, y, w, h), 2))
                {
                    g.DrawPath(pen, path);
                }

                // Cross grid lines or X symbol
                using (Font xFont = new Font("Segoe UI", 9f, FontStyle.Bold))
                using (SolidBrush brush = new SolidBrush(color))
                {
                    StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString("X", xFont, brush, new RectangleF(x, y, w, h), sf);
                }
            }
        }

        /// <summary>
        /// Draws a Close (X in circle or X) icon.
        /// </summary>
        public static void DrawCloseIcon(Graphics g, Rectangle bounds, Color color, float penWidth = 1.6f)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(color, penWidth))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                // Circle outline
                int pad = 2;
                Rectangle circleRect = new Rectangle(bounds.X + pad, bounds.Y + pad, bounds.Width - pad * 2, bounds.Height - pad * 2);
                g.DrawEllipse(pen, circleRect);

                // X inside
                int cx = bounds.X + bounds.Width / 2;
                int cy = bounds.Y + bounds.Height / 2;
                int s = (int)(bounds.Width * 0.18f);
                g.DrawLine(pen, cx - s, cy - s, cx + s, cy + s);
                g.DrawLine(pen, cx + s, cy - s, cx - s, cy + s);
            }
        }

        /// <summary>
        /// Draws a Paper Airplane / Send / Submit icon.
        /// </summary>
        public static void DrawSendIcon(Graphics g, Rectangle bounds, Color color, float penWidth = 1.6f)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(color, penWidth))
            using (SolidBrush brush = new SolidBrush(color))
            {
                pen.LineJoin = LineJoin.Round;
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                int x = bounds.X + 2;
                int y = bounds.Y + 2;
                int w = bounds.Width - 4;
                int h = bounds.Height - 4;

                Point[] plane = new Point[] {
                    new Point(x + w, y),
                    new Point(x, y + (int)(h * 0.45f)),
                    new Point(x + (int)(w * 0.45f), y + (int)(h * 0.55f)),
                    new Point(x + (int)(w * 0.55f), y + h),
                    new Point(x + w, y)
                };
                g.DrawLines(pen, plane);
                g.DrawLine(pen, x + (int)(w * 0.45f), y + (int)(h * 0.55f), x + w, y);
            }
        }

        /// <summary>
        /// Draws a Refresh / Clear icon.
        /// </summary>
        public static void DrawRefreshIcon(Graphics g, Rectangle bounds, Color color, float penWidth = 1.8f)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(color, penWidth))
            using (SolidBrush brush = new SolidBrush(color))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                int cx = bounds.X + bounds.Width / 2;
                int cy = bounds.Y + bounds.Height / 2;
                int r = bounds.Width / 3;

                g.DrawArc(pen, cx - r, cy - r, r * 2, r * 2, 40, 270);

                // Arrow head at top
                int ax = cx + (int)(r * 0.7f);
                int ay = cy - (int)(r * 0.7f);
                Point[] arrow = new Point[] {
                    new Point(ax - 2, ay - 4),
                    new Point(ax + 3, ay),
                    new Point(ax - 3, ay + 2)
                };
                g.FillPolygon(brush, arrow);
            }
        }

        /// <summary>
        /// Draws a Chevron Right (>) icon for sidebar navigation.
        /// </summary>
        public static void DrawChevronRight(Graphics g, Rectangle bounds, Color color, float penWidth = 1.6f)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(color, penWidth))
            {
                pen.LineJoin = LineJoin.Round;
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                int cx = bounds.X + bounds.Width / 2;
                int cy = bounds.Y + bounds.Height / 2;
                int s = bounds.Height / 4;

                g.DrawLines(pen, new Point[] {
                    new Point(cx - s / 2, cy - s),
                    new Point(cx + s / 2, cy),
                    new Point(cx - s / 2, cy + s)
                });
            }
        }

        public static GraphicsPath CreateRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int diameter = radius * 2;
            Rectangle arc = new Rectangle(rect.X, rect.Y, diameter, diameter);

            // Top-left
            path.AddArc(arc, 180, 90);

            // Top-right
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom-right
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom-left
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        // =========================================================================
        // HD Vector Bitmap Generators for WinForms Buttons and Visual Controls
        // =========================================================================

        public static Bitmap CreateExcelBitmap(int w = 16, int h = 16, Color? color = null)
        {
            Bitmap bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                DrawExcelIcon(g, new Rectangle(0, 0, w, h), color ?? Color.FromArgb(22, 163, 74));
            }
            return bmp;
        }

        public static Bitmap CreateCloseBitmap(int w = 16, int h = 16, Color? color = null)
        {
            Bitmap bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                DrawCloseIcon(g, new Rectangle(0, 0, w, h), color ?? Color.FromArgb(100, 116, 139));
            }
            return bmp;
        }

        public static Bitmap CreateSendBitmap(int w = 16, int h = 16, Color? color = null)
        {
            Bitmap bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                DrawSendIcon(g, new Rectangle(0, 0, w, h), color ?? Color.White);
            }
            return bmp;
        }

        public static Bitmap CreateRefreshBitmap(int w = 16, int h = 16, Color? color = null)
        {
            Bitmap bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                DrawRefreshIcon(g, new Rectangle(0, 0, w, h), color ?? Color.FromArgb(71, 85, 105));
            }
            return bmp;
        }

        public static Bitmap CreateCartBitmap(int w = 16, int h = 16, Color? color = null)
        {
            Bitmap bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                DrawCartIcon(g, new Rectangle(0, 0, w, h), color ?? Color.FromArgb(14, 125, 70));
            }
            return bmp;
        }

        public static Bitmap CreateChevronRightBitmap(int w = 12, int h = 12, Color? color = null)
        {
            Bitmap bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                DrawChevronRight(g, new Rectangle(0, 0, w, h), color ?? Color.FromArgb(156, 163, 175));
            }
            return bmp;
        }

        public static Bitmap CreateAddBitmap(int w = 14, int h = 14, Color? color = null)
        {
            Bitmap bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Color c = color ?? Color.FromArgb(14, 125, 70);
                using (Pen pen = new Pen(c, 2.0f))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    int cx = w / 2;
                    int cy = h / 2;
                    int r = Math.Min(w, h) / 3;
                    g.DrawLine(pen, cx, cy - r, cx, cy + r);
                    g.DrawLine(pen, cx - r, cy, cx + r, cy);
                }
            }
            return bmp;
        }

        public static Bitmap CreateDeleteBitmap(int w = 14, int h = 14, Color? color = null)
        {
            Bitmap bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Color c = color ?? Color.FromArgb(220, 38, 38);
                using (Pen pen = new Pen(c, 2.0f))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    int cx = w / 2;
                    int cy = h / 2;
                    int r = Math.Min(w, h) / 3;
                    g.DrawLine(pen, cx - r, cy - r, cx + r, cy + r);
                    g.DrawLine(pen, cx + r, cy - r, cx - r, cy + r);
                }
            }
            return bmp;
        }

        /// <summary>
        /// Renders the subtle pastel green watermark illustration in the bottom-left sidebar
        /// consisting of plant leaves, checklist clipboard, and stacked shipment boxes.
        /// </summary>
        public static void DrawSidebarWatermarkIllustration(Graphics g, Rectangle bounds)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            int x = bounds.X + 6;
            int y = bounds.Y;
            int w = bounds.Width - 12;
            int h = bounds.Height;

            // Palette
            Color paleGreen   = Color.FromArgb(232, 245, 233);      // #E8F5E9
            Color softMint    = Color.FromArgb(209, 250, 229);       // #D1FAE5
            Color lightBorder = Color.FromArgb(167, 243, 208);     // #A7F3D0
            Color greenAccent = Color.FromArgb(110, 231, 183);     // #6EE7B7

            // 1. Plant leaves on the left
            using (SolidBrush leafBrush = new SolidBrush(Color.FromArgb(160, 200, 240, 220)))
            using (Pen stemPen = new Pen(Color.FromArgb(140, 110, 231, 183), 1.5f))
            {
                // Curved stem
                g.DrawBezier(stemPen, x + 15, y + h - 10, x + 10, y + h / 2, x + 5, y + 25, x + 12, y + 10);

                // Leaf 1
                using (GraphicsPath leaf1 = new GraphicsPath())
                {
                    leaf1.AddArc(x + 6, y + 8, 20, 30, 200, 160);
                    leaf1.AddArc(x - 4, y + 8, 20, 30, 20, 160);
                    g.FillPath(leafBrush, leaf1);
                }

                // Leaf 2
                using (GraphicsPath leaf2 = new GraphicsPath())
                {
                    leaf2.AddArc(x + 10, y + 28, 22, 24, 230, 160);
                    leaf2.AddArc(x, y + 28, 22, 24, 50, 160);
                    g.FillPath(leafBrush, leaf2);
                }
            }

            // 2. Clipboard in center
            int clipW = 54;
            int clipH = 70;
            int clipX = x + 26;
            int clipY = y + 10;

            Rectangle boardRect = new Rectangle(clipX, clipY, clipW, clipH);
            using (GraphicsPath boardPath = CreateRoundedRectPath(boardRect, 6))
            {
                using (SolidBrush boardBrush = new SolidBrush(paleGreen))
                {
                    g.FillPath(boardBrush, boardPath);
                }
                using (Pen boardPen = new Pen(lightBorder, 1.4f))
                {
                    g.DrawPath(boardPen, boardPath);
                }
            }

            // Top clip of clipboard
            Rectangle topClipRect = new Rectangle(clipX + (clipW - 22) / 2, clipY - 4, 22, 7);
            using (GraphicsPath topClipPath = CreateRoundedRectPath(topClipRect, 3))
            {
                using (SolidBrush clipBrush = new SolidBrush(softMint))
                {
                    g.FillPath(clipBrush, topClipPath);
                }
                using (Pen clipPen = new Pen(lightBorder, 1.2f))
                {
                    g.DrawPath(clipPen, topClipPath);
                }
            }

            // Checklist lines on the clipboard
            using (Pen checkPen = new Pen(greenAccent, 1.4f))
            using (SolidBrush checkBg = new SolidBrush(Color.White))
            {
                for (int i = 0; i < 4; i++)
                {
                    int lineY = clipY + 14 + (i * 12);

                    // Checkbox square
                    Rectangle box = new Rectangle(clipX + 7, lineY, 8, 8);
                    g.FillRectangle(checkBg, box);
                    g.DrawRectangle(checkPen, box);

                    if (i < 2) // Checkmarks inside top 2 boxes
                    {
                        g.DrawLines(checkPen, new Point[] {
                            new Point(box.X + 2, box.Y + 4),
                            new Point(box.X + 4, box.Y + 6),
                            new Point(box.X + 7, box.Y + 2)
                        });
                    }

                    // Horizontal line
                    g.DrawLine(checkPen, clipX + 18, lineY + 4, clipX + clipW - 8, lineY + 4);
                }
            }

            // 3. Stacked packages / boxes on the right
            int boxX = clipX + 36;
            int boxY = clipY + 32;

            // Base Box 1
            Rectangle b1 = new Rectangle(boxX - 6, boxY + 16, 36, 22);
            DrawPackageBox(g, b1, softMint, lightBorder, greenAccent);

            // Box 2 (stacked)
            Rectangle b2 = new Rectangle(boxX + 14, boxY + 6, 28, 18);
            DrawPackageBox(g, b2, paleGreen, lightBorder, greenAccent);

            // Box 3 (top)
            Rectangle b3 = new Rectangle(boxX + 2, boxY - 6, 24, 16);
            DrawPackageBox(g, b3, Color.FromArgb(240, 253, 244), lightBorder, greenAccent);
        }

        private static void DrawPackageBox(Graphics g, Rectangle rect, Color bg, Color border, Color tape)
        {
            using (GraphicsPath path = CreateRoundedRectPath(rect, 3))
            using (SolidBrush brush = new SolidBrush(bg))
            using (Pen pen = new Pen(border, 1.2f))
            using (Pen tapePen = new Pen(tape, 1f))
            {
                g.FillPath(brush, path);
                g.DrawPath(pen, path);

                int midX = rect.X + rect.Width / 2;
                g.DrawLine(tapePen, midX, rect.Y, midX, rect.Bottom);
            }
        }
    }
}

