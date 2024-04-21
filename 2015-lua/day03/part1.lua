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
local x = 0
local y = 0

local function send (x, y)
    local key = tostring(x) .. ',' .. tostring(y)
    if not map[key] then
        sum  = sum + 1
        map[key] = true
    end
end

sum = 0
send(x, y)

for i = 1, #content do
    local c = content:sub(i, i)
    
    if c == '<' then
        x = x - 1
        send(x, y)
    elseif c == '>' then
        x = x + 1
        send(x, y)
    elseif c == '^' then
        y = y + 1
        send(x, y)
    else
        y = y - 1
        send(x, y)
    end
end

print('sum:', sum)