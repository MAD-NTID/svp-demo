
from random import *
from turtle import *

def random_color():
    colormode(255)
    return (randint(0, 255), randint(0, 255), randint(0, 255))

def draw_polygon(n, sz):
    for i in range(n):
        pencolor(random_color())
        forward(sz)
        left(360/n)

def draw_kaleido(p, n, sz):
    for i in range(p):
        draw_polygon(n, sz)
        left(int(360/p))

def draw_random_polygon(n, sz):
    for i in range(int(360/n)):
        forward(sz)
        angle = randint(0, 360)
        left(angle)

if __name__ == "__main__":
    print("Drawing a kaleido...")
    s = getscreen()
    bgcolor("black")
    clear()
    speed(0)
    pensize(2)
    draw_kaleido(36, 5, 70)
    # penup()
    # goto(50, 50)
    # pendown()
    # pencolor("blue")
    # draw_random_polygon(9, 40)
    done()
