
import random
import turtle

def draw_polygon(t, n, sz):
    for i in range(n):
        t.forward(sz)
        t.left(360/n)

def draw_kaleido(t, n, sz):
    for i in range(24):
        draw_polygon(t, n, sz)
        t.left(15)

def draw_random_polygon(t, n, sz):
    for i in range(int(360/n)):
        t.forward(sz)
        t.left(random.randint(0, int(360/n)))

if __name__ == "__main__":
    print("Drawing a kaleido...")
    s = turtle.getscreen()
    turtle.bgcolor("black")
    t = turtle.Turtle()
    t.clear()
    t.speed(0)
    t.penup()
    t.goto(-200, -200)
    t.pendown()
    t.pencolor("red")
    draw_kaleido(t, 5, 75)
    t.penup()
    t.goto(50, 50)
    t.pendown()
    t.pencolor("blue")
    draw_random_polygon(t, 9, 40)
    turtle.done()
