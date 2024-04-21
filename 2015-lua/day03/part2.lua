-- Open the file for reading
local file = io.open('input.txt', 'r')
if not file then
    error("Failed to open file")
end

-- Read the entire content of the file
local content = file:read('*a')

-- Close the file
file:close()

local map = {}
local santa = { x = 0, y = 0 }
local robot = { x = 0, y = 0 }

local function send (x, y)
    local key = tostring(x) .. ',' .. tostring(y)
    if not map[key] then
        sum  = sum + 1
        map[key] = true
    end
end

sum = 0
isSantaTurn = true
send(0, 0)

for i = 1, #content do
    local c = content:sub(i, i)
    
    local curDelivery
    if isSantaTurn then
        curDelivery = santa
    else
        curDelivery = robot
    end

    if c == '<' then
        curDelivery.x = curDelivery.x - 1
    elseif c == '>' then
        curDelivery.x = curDelivery.x + 1
    elseif c == '^' then
        curDelivery.y = curDelivery.y + 1
    else
        curDelivery.y = curDelivery.y - 1
    end
    
    send(curDelivery.x, curDelivery.y)
    
    isSantaTurn = not isSantaTurn
end

print('sum:', sum)